using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ���
    public Transform firePoint; // �����, � ��� ���� ������������� ����

    private void Update()
    {
        // �������� �� ���������� ���
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // ��������� ���� � ������� � ����� �������
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
