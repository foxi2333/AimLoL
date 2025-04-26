using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource; // Аудіо джерело
    public AudioClip footstepSound; // Звук кроків
    public float stepInterval = 0.5f; // Інтервал між кроками (секунди)

    private float stepTimer = 0f; // Таймер для кроків

    void Update()
    {
        // Якщо гравець рухається (потрібно перевірити, чи є рух)
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval) // Якщо пройшло достатньо часу між кроками
            {
                PlayFootstepSound();
                stepTimer = 0f; // Скидаємо таймер
            }
        }
    }

    void PlayFootstepSound()
    {
        if (footstepAudioSource != null && footstepSound != null)
        {
            footstepAudioSource.PlayOneShot(footstepSound); // Відтворюємо звук кроків
        }
    }
}

