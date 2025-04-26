using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChase : MonoBehaviour
{
    public float speed = 3f;
    public float delayBeforeChase = 5f;
    private Transform player;
    private bool isChasing = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isChasing)
        {
            player = other.transform;
            StartCoroutine(StartChaseAfterDelay());
        }
    }

    IEnumerator StartChaseAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeChase);
        isChasing = true;
    }

    void Update()
    {
        if (isChasing && player != null)
        {
            // Ігноруємо вісь Y
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            Vector3 direction = (targetPosition - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(targetPosition);
        }
    }
}
