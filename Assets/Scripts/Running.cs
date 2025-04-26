using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moved = Vector3.Distance(transform.position, startPos);

        if (moved >= distance)
            movingForward = !movingForward;

        Vector3 direction = movingForward ? Vector3.forward : Vector3.back;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
