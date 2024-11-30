using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // Швидкість кулі
    public float lifeTime = 5f; // Час до знищення кулі, якщо вона не потрапила в об'єкт

    private Rigidbody rb;

    private void Start()
    {
        // Отримуємо компонент Rigidbody
        rb = GetComponent<Rigidbody>();


        // Видаляємо кулю через певний час, якщо вона не потрапила в об'єкт
        Destroy(gameObject, lifeTime);

        // Встановлюємо початкову швидкість кулі в напрямку вперед
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Перевірка, чи об'єкт, з яким зіткнулася куля, має скрипт з змінною життя
        //var healthScript = collision.gameObject.GetComponent<Health>();

       // if (healthScript != null)
       // {
            // Якщо є змінна життя, віднімаємо 10 одиниць
      //      healthScript.TakeDamage(10);
      //  }

        // У будь-якому випадку знищуємо кулю
       // Destroy(gameObject);
    }
}
