using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // Початкове здоров'я
    public Text DamageTxt;
    public GameObject TextObj;
    public AudioSource audioSource;
    public AudioClip SoundeOfHit;


 

    // Метод для зменшення здоров'я
    public void TakeDamage(float damage)

    {
        {
            // Ініціалізуємо AudioSource
            audioSource = GetComponent<AudioSource>();

            health -= damage; // Зменшуємо здоров'я
            TextObj.SetActive(true); // Активуємо текстовий об'єкт
            DamageTxt.text = "HP: " + health.ToString("0.0"); // Оновлюємо текст із поточним здоров'ям

            if (audioSource != null)
            {
                audioSource.PlayOneShot(SoundeOfHit, 0.7F);
            }
            // Якщо здоров'я менше або рівне нулю, знищуємо об'єкт
            if (health <= 0)
            {
                Destroy(gameObject); // Знищуємо об'єкт противника
            }


            

        }
    
    }
}
