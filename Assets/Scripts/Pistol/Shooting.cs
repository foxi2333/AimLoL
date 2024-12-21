using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // The delay between shots in seconds
    public float shotDelay = 0.0001f;

    // Variable to track when the next shot can be fired
    private float lastShotTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= lastShotTime + shotDelay)
        {
            ShootBullet();
            lastShotTime = Time.time; // Update the last shot time
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
