using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Двері")]
    public GameObject door; // Об'єкт дверей
    public AudioClip doorDisappearSound; // Звук для зникнення дверей
    public ParticleSystem doorEffect; // Ефект при зникненні дверей
    private AudioSource audioSource;

    [Header("Вороги")]
    public List<GameObject> enemies; // Список ворогів

    private bool isDoorRemoved = false;

    void Start()
    {
        // Ініціалізація джерела звуку
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Перевірка чи всі вороги мертві
        CheckEnemiesStatus();

        // Видалення дверей, якщо всі вороги мертві
        if (!isDoorRemoved && enemies.Count == 0)
        {
            RemoveDoor();
        }
    }

    void CheckEnemiesStatus()
    {
        // Видалення мертвих ворогів зі списку
        enemies.RemoveAll(enemy => enemy == null);
    }

    void RemoveDoor()
    {
        if (door != null)
        {
            // Відтворення звуку
            if (doorDisappearSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(doorDisappearSound);
            }

            // Відтворення ефекту
            if (doorEffect != null)
            {
                Instantiate(doorEffect, door.transform.position, Quaternion.identity);
            }

            // Затримка перед зникненням дверей (щоб ефект встиг відіграти)
            StartCoroutine(DestroyDoorWithDelay());
        }
    }

    IEnumerator DestroyDoorWithDelay()
    {
        yield return new WaitForSeconds(0.5f); // Час для ефекту (можеш змінити)
        Destroy(door);
        isDoorRemoved = true;
    }
}