using System.Collections;
using UnityEngine;

public class AK47BalleticShooting : MonoBehaviour
{
    public Transform gunBarrel; // Місце, де з'являються кулі (ствол)
    public GameObject bulletPrefab; // Префаб кулі
    public float bulletSpeed = 40f; // Початкова швидкість кулі
    public float fireRate = 0.1f; // Швидкість стрільби (пауза між пострілами)
    private float nextFireTime = 0f; // Час до наступного пострілу
    public AudioSource gunSound; // Звук пострілу
    public AudioSource emptyGunSound; // Звук пустого магазину
    public Animator gunAnimator; // Аніматор для віддачі
    public ParticleSystem muzzleFlash; // Ефект муцлефлешу
    public UIManager uiManager; // Управління UI для відображення кількості куль та магазинів

    // Параметри магазину
    public int maxAmmoInClip = 30; // Максимальна кількість патронів у магазині
    public int maxMagazines = 5; // Кількість магазинів
    private int currentAmmo; // Поточна кількість патронів у магазині
    private int remainingMagazines; // Кількість залишкових магазинів

    private bool isReloading = false; // Статус перезарядки

    private void Start()
    {

        currentAmmo = maxAmmoInClip; // Спочатку в магазині максимальна кількість патронів
        remainingMagazines = maxMagazines; // Спочатку є максимальна кількість магазинів
        UpdateAmmoUI(); // Оновлюємо UI відразу
    }

    private void Update()
    {
        // Перевірка, чи натиснута кнопка для стрільби
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0 && !isReloading)
        {
            Fire();
        }

        // Перевірка на перезарядку
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < maxAmmoInClip && remainingMagazines > 0)
        {
            StartCoroutine(Reload());
        }

        // Якщо патронів немає, відтворюємо звук порожнього магазину
        if (currentAmmo == 0 && Input.GetButton("Fire1") && !isReloading)
        {
            if (!emptyGunSound.isPlaying)
            {
                emptyGunSound.Play();
            }
        }
    }

    void Fire()
    {

        nextFireTime = Time.time + fireRate;

 

        // Відтворення звуку пострілу
        if (gunSound != null)
        {
            gunSound.Play();
        }

        // Відтворення ефекту муцлефлешу
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // Відтворення анімації віддачі
        if (gunAnimator != null)
        {
            gunAnimator.SetTrigger("Shoot");
        }


        // Зменшуємо кількість патронів
        currentAmmo--;

        // Оновлення UI для кількості патронів
        UpdateAmmoUI();
    }

    IEnumerator Reload()
    {
        if (remainingMagazines > 0)
        {
            isReloading = true;

            // Оновлюємо UI, що почалася перезарядка
            uiManager.ShowReloading(true);

            // Пауза для анімації перезарядки
            yield return new WaitForSeconds(2f); // Тривалість перезарядки (можна налаштувати)

            // Перезаряджаємо магазин
            int ammoToReload = maxAmmoInClip - currentAmmo;
            if (remainingMagazines > 0)
            {
                // Якщо в магазині залишилися патрони, перезаряджаємо
                if (remainingMagazines > 0)
                {
                    currentAmmo = maxAmmoInClip;
                    remainingMagazines--;
                }
            }

            // Завершення перезарядки
            isReloading = false;
            uiManager.ShowReloading(false); // Оновлення UI
            UpdateAmmoUI(); // Оновлення UI після перезарядки
        }
        else
        {
            // Якщо немає магазинів, зупиняємо перезарядку
            Debug.Log("Немає магазинів!");
        }
    }

    // Оновлення UI для кількості патронів і магазинів
    void UpdateAmmoUI()
    {
        if (uiManager != null)
        {
            uiManager.UpdateAmmoCount(currentAmmo, maxAmmoInClip);
            uiManager.UpdateMagazineCount(remainingMagazines, maxMagazines);
        }
    }
}