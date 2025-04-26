using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float chaseDistance = 5f;
    public Transform player;
    public AudioSource audioSource;
    public AudioClip walkClip;

    private bool isChasing = false;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            if (!isChasing)
            {
                StartChasing();
            }
        }
        else
        {
            if (isChasing)
            {
                StopChasing();
            }
        }
    }

    void StartChasing()
    {
        isChasing = true;
        Debug.Log("Почав переслідувати гравця");

        if (walkClip != null)
        {
            audioSource.clip = walkClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void StopChasing()
    {
        isChasing = false;
        Debug.Log("Припинив переслідування");

        audioSource.Stop();
    }
}

