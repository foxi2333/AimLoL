using System.Collections;
using UnityEngine;

public class AK47BalleticShooting : MonoBehaviour
{
    public Transform gunBarrel; // ̳���, �� �'��������� ��� (�����)
    public GameObject bulletPrefab; // ������ ���
    public float bulletSpeed = 40f; // ��������� �������� ���
    public float fireRate = 0.1f; // �������� ������� (����� �� ���������)
    private float nextFireTime = 0f; // ��� �� ���������� �������
    public AudioSource gunSound; // ���� �������
    public AudioSource emptyGunSound; // ���� ������� ��������
    public Animator gunAnimator; // ������� ��� ������
    public ParticleSystem muzzleFlash; // ����� ����������
    public UIManager uiManager; // ��������� UI ��� ����������� ������� ���� �� ��������

    // ��������� ��������
    public int maxAmmoInClip = 30; // ����������� ������� ������� � �������
    public int maxMagazines = 5; // ʳ������ ��������
    private int currentAmmo; // ������� ������� ������� � �������
    private int remainingMagazines; // ʳ������ ���������� ��������

    private bool isReloading = false; // ������ �����������

    private void Start()
    {

        currentAmmo = maxAmmoInClip; // �������� � ������� ����������� ������� �������
        remainingMagazines = maxMagazines; // �������� � ����������� ������� ��������
        UpdateAmmoUI(); // ��������� UI ������
    }

    private void Update()
    {
        // ��������, �� ��������� ������ ��� �������
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0 && !isReloading)
        {
            Fire();
        }

        // �������� �� �����������
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < maxAmmoInClip && remainingMagazines > 0)
        {
            StartCoroutine(Reload());
        }

        // ���� ������� ����, ���������� ���� ���������� ��������
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

 

        // ³��������� ����� �������
        if (gunSound != null)
        {
            gunSound.Play();
        }

        // ³��������� ������ ����������
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // ³��������� ������� ������
        if (gunAnimator != null)
        {
            gunAnimator.SetTrigger("Shoot");
        }


        // �������� ������� �������
        currentAmmo--;

        // ��������� UI ��� ������� �������
        UpdateAmmoUI();
    }

    IEnumerator Reload()
    {
        if (remainingMagazines > 0)
        {
            isReloading = true;

            // ��������� UI, �� �������� �����������
            uiManager.ShowReloading(true);

            // ����� ��� ������� �����������
            yield return new WaitForSeconds(2f); // ��������� ����������� (����� �����������)

            // ������������� �������
            int ammoToReload = maxAmmoInClip - currentAmmo;
            if (remainingMagazines > 0)
            {
                // ���� � ������� ���������� �������, �������������
                if (remainingMagazines > 0)
                {
                    currentAmmo = maxAmmoInClip;
                    remainingMagazines--;
                }
            }

            // ���������� �����������
            isReloading = false;
            uiManager.ShowReloading(false); // ��������� UI
            UpdateAmmoUI(); // ��������� UI ���� �����������
        }
        else
        {
            // ���� ���� ��������, ��������� �����������
            Debug.Log("���� ��������!");
        }
    }

    // ��������� UI ��� ������� ������� � ��������
    void UpdateAmmoUI()
    {
        if (uiManager != null)
        {
            uiManager.UpdateAmmoCount(currentAmmo, maxAmmoInClip);
            uiManager.UpdateMagazineCount(remainingMagazines, maxMagazines);
        }
    }
}