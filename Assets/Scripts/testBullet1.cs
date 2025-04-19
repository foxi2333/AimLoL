using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class AK47BalleticShooting111 : MonoBehaviour
{
    public AudioSource reloadGunSound;
    public Transform bulletSpawnPoint; // Місце, де з'являються кулі (ствол)
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

    // Нові параметри для видимості зброї
    public Renderer gunRenderer; // Рендерер зброї для зміни видимості
    public bool isGunVisible = true; // Чи видима зброя за замовчуванням

    private void Start()
    {
        currentAmmo = maxAmmoInClip; // Спочатку в магазині максимальна кількість патронів
        remainingMagazines = maxMagazines; // Спочатку є максимальна кількість магазинів
        UpdateAmmoUI(); // Оновлюємо UI відразу
        UpdateGunVisibility(); // Оновлюємо видимість зброї при старті
    }

    private void Update()
    {
        // Перевірка, чи натиснута кнопка для стрільби
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && !isReloading)
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

        // Зміна видимості зброї при натисканні клавіші F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isGunVisible = !isGunVisible;
            UpdateGunVisibility();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
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
            currentAmmo = maxAmmoInClip;
            remainingMagazines--;

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

    // Оновлення видимості зброї
    void UpdateGunVisibility()
    {
        if (gunRenderer != null)
        {
            gunRenderer.enabled = isGunVisible;
        }
    }
}
