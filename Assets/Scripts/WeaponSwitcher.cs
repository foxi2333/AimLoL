using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject AK47;      // Калашніков
    public GameObject M16;      // M4A4

    private GameObject currentWeapon;

    void Start()
    {
        // Спочатку вибираємо калашніков
        currentWeapon = AK47;
        currentWeapon.SetActive(true);

        // Вимикаємо M4A4
        M16.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 — калашніков
        {
            SwitchWeapon(AK47);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 — M4A4
        {
            SwitchWeapon(M16);
        }
    }

    // Функція для зміни зброї
    void SwitchWeapon(GameObject newWeapon)
    {
        // Вимикаємо поточну зброю
        currentWeapon.SetActive(false);

        // Включаємо нову зброю
        newWeapon.SetActive(true);

        // Оновлюємо поточну зброю
        currentWeapon = newWeapon;
    }
}