using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher1 : MonoBehaviour
{
    public GameObject AK47;      // ���������
    public GameObject M16;       // M4A4
    public GameObject Grenade;
    public GameObject CS_USP;    // ϳ������ USP

    private GameObject currentWeapon;

    void Start()
    {
        // �������� �������� ���������
        currentWeapon = AK47;
        currentWeapon.SetActive(true);

        // �������� ���� ���� ����
        M16.SetActive(false);
        Grenade.SetActive(false);
        CS_USP.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 � ���������
        {
            SwitchWeapon(AK47);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 � M4A4
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

    // ������� ��� ���� ����
    void SwitchWeapon(GameObject newWeapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }

        // �������� ���� �����
        newWeapon.SetActive(true);

        // ��������� ������� �����
        currentWeapon = newWeapon;
    }
}
