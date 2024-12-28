using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m416SHOOT : MonoBehaviour
{
   
    

public class RifleReload : MonoBehaviour
{
    public int currentAmmo = 0;        // ������� ������� �������
    public int maxAmmo = 30;           // ����������� ������� ������� � �������
    public bool isReloading = false;   // �� ���������� �����������
    public float reloadTime = 2f;      // ��� ��� �����������
    public Animator animator;          // ������� ��� ��������

    void Update()
    {
        // ��������, �� ������� ���������� � ���������� ������ "R"
        if (currentAmmo == 0 && !isReloading && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    // ������� ��� �����������
    IEnumerator Reload()
    {
        isReloading = true;

        // ��������� ������� �����������
        animator.SetTrigger("Reload");

        // ������, ���� ������� ����������� �����������
        yield return new WaitForSeconds(reloadTime);

        // ϳ��� ���������� �����������, ������������ ����������� ������� �������
        currentAmmo = maxAmmo;

        isReloading = false;
    }

    // ������� ��� ������� (�� ����'������, ��� ��� �����)
    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            // ��� ������� ��� ��� �������
        }
        else
        {
            Debug.Log("������� ����������!");
        }
    }
}

}

