using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб кулі
    public Transform firePoint; // Точка, з якої буде вистрілюватись куля

    private void Update()
    {
        // Перевірка на натискання ЛКМ
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Створюємо кулю з префабу в точці пострілу
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
