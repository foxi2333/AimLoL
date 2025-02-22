using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher1 : MonoBehaviour
{
    public GameObject AK47;      // Калашніков
    public GameObject M16;       // M4A4
    public GameObject Grenade;
    public GameObject CS_USP;    // Пістолет USP

    private GameObject currentWeapon;

    void Start()
    {
        // Спочатку вибираємо калашніков
        currentWeapon = AK47;
        currentWeapon.SetActive(true);

        // Вимикаємо інші види зброї
        M16.SetActive(false);
        Grenade.SetActive(false);
        CS_USP.SetActive(false);
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
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 3 - grenade launcher
        {
            SwitchWeapon(Grenade);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) // 4 - USP
        {
            SwitchWeapon(CS_USP);
        }
    }

    // Функція для зміни зброї
    void SwitchWeapon(GameObject newWeapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }

        // Включаємо нову зброю
        newWeapon.SetActive(true);

        // Оновлюємо поточну зброю
        currentWeapon = newWeapon;
    }
}
