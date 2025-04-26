using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10;  // Скільки урону завдається

    void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи зіткнувся з гравцем (який має тег "Player")
        if (other.CompareTag("Player"))
        {
            // Отримуємо компонент PlayerHealth у гравця та завдаємо урон
            other.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
