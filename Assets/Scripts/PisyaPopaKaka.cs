using UnityEngine;

public class EnemyHealth1 : MonoBehaviour
{
    public float health = 100f;  // Поточне здоров'я
    public GameObject enemyPrefab;  // Префаб об'єкта для спавну нового

    public Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // Координати для спавну

    // Метод для отримання пошкодження
    public void TakeDamage(float damage)
    {
        health -= damage;

        // Якщо здоров'я менше або рівне нулю, зруйнувати об'єкт і спавнити новий
        if (health <= 0)
        {
            Destroy(gameObject);  // Зруйнувати поточний об'єкт

            // Спавнити новий об'єкт на вказаних координатах
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Префаб на вказаних координатах
        }
    }
}