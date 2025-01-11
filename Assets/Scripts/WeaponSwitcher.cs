using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject AK47;      // ���������
    public GameObject M16;      // M4A4

    private GameObject currentWeapon;

    void Start()
    {
        // �������� �������� ���������
        currentWeapon = AK47;
        currentWeapon.SetActive(true);

        // �������� M4A4
        M16.SetActive(false);
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
    }

    // ������� ��� ���� ����
    void SwitchWeapon(GameObject newWeapon)
    {
        // �������� ������� �����
        currentWeapon.SetActive(false);

        // �������� ���� �����
        newWeapon.SetActive(true);

        // ��������� ������� �����
        currentWeapon = newWeapon;
    }
}