using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("����")]
    public GameObject door; // ��'��� ������
    public AudioClip doorDisappearSound; // ���� ��� ��������� ������
    public ParticleSystem doorEffect; // ����� ��� �������� ������
    private AudioSource audioSource;

    [Header("������")]
    public List<GameObject> enemies; // ������ ������

    private bool isDoorRemoved = false;

    void Start()
    {
        // ����������� ������� �����
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // �������� �� �� ������ �����
        CheckEnemiesStatus();

        // ��������� ������, ���� �� ������ �����
        if (!isDoorRemoved && enemies.Count == 0)
        {
            RemoveDoor();
        }
    }

    void CheckEnemiesStatus()
    {
        // ��������� ������� ������ � ������
        enemies.RemoveAll(enemy => enemy == null);
    }

    void RemoveDoor()
    {
        if (door != null)
        {
            // ³��������� �����
            if (doorDisappearSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(doorDisappearSound);
            }

            // ³��������� ������
            if (doorEffect != null)
            {
                Instantiate(doorEffect, door.transform.position, Quaternion.identity);
            }

            // �������� ����� ���������� ������ (��� ����� ����� �������)
            StartCoroutine(DestroyDoorWithDelay());
        }
    }

    IEnumerator DestroyDoorWithDelay()
    {
        yield return new WaitForSeconds(0.5f); // ��� ��� ������ (����� ������)
        Destroy(door);
        isDoorRemoved = true;
    }
}