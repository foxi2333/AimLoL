using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // Початкове здоров'я

    // Метод для зменшення здоров'я
    public void TakeDamage(float damage)
    {
        health -= damage;

        // Якщо здоров'я менше або рівне нулю, знищуємо об'єкт
        if (health <= 0)
        {
            Destroy(gameObject);  // Знищуємо об'єкт противника
        }
    }
}