using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip SoundeOfHit;
    public AudioSource audioSource;
    //public float PlayOneShot;
    public float damage = 20f;
    public float speed = 0.005f; // Швидкість кулі 
    public float lifeTime = 5f; // Час до знищення кулі, якщо вона не потрапила в об'єкт

    private Rigidbody rb;
  
    private void OnCollisionEnter(Collision collision)
    {
        print("print4");
        // Перевіряємо, чи це об'єкт противника
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(SoundeOfHit, 0.7F);
            print("print1");         // Отримуємо скрипт EnemyHealth з об'єкта, з яким відбулося зіткнення
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            
            // Якщо скрипт знайдено, завдаємо шкоди
            if (enemyHealth != null)
            {
                print("print2");
                enemyHealth.TakeDamage(damage);
            }

            // Знищуємо кулю після зіткнення
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Отримуємо компонент Rigidbody
        rb = GetComponent<Rigidbody>();


        // Видаляємо кулю через певний час, якщо вона не потрапила в об'єкт
        Destroy(gameObject, lifeTime);

        // Встановлюємо початкову швидкість кулі в напрямку вперед
        rb.velocity = transform.forward * speed;
    }

    
}
