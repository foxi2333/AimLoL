using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkClip;
    public AudioClip attackClip;
    public AudioClip deathClip;

    public Transform player; // Посилання на гравця
    public float minDistanceToPlayWalkSound = 0.5f; // Мінімальна відстань для кроків

    private bool isWalkingSoundPlaying = false;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform; // Знаходимо гравця автоматично
    }

    void Update()
    {
        HandleWalkingSound();
    }

    void HandleWalkingSound()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > minDistanceToPlayWalkSound) // Якщо ворог далеко від гравця — значить іде
        {
            if (!isWalkingSoundPlaying)
            {
                audioSource.clip = walkClip;
                audioSource.loop = true;
                audioSource.Play();
                isWalkingSoundPlaying = true;
            }
        }
        else
        {
            if (isWalkingSoundPlaying)
            {
                audioSource.Stop();
                isWalkingSoundPlaying = false;
            }
        }
    }

    public void PlayAttackSound()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.loop = false;
        audioSource.clip = attackClip;
        audioSource.Play();
        isWalkingSoundPlaying = false;
    }

    public void PlayDeathSound()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.loop = false;
        audioSource.clip = deathClip;
        audioSource.Play();
        isWalkingSoundPlaying = false;
    }
}
