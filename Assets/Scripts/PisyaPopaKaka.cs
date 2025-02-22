using UnityEngine;

public class EnemyHealth1 : MonoBehaviour
{
    public float health = 100f;  // ������� ������'�
    public GameObject enemyPrefab;  // ������ ��'���� ��� ������ ������

    public Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // ���������� ��� ������

    // ����� ��� ��������� �����������
    public void TakeDamage(float damage)
    {
        health -= damage;

        // ���� ������'� ����� ��� ���� ����, ���������� ��'��� � �������� �����
        if (health <= 0)
        {
            Destroy(gameObject);  // ���������� �������� ��'���

            // �������� ����� ��'��� �� �������� �����������
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // ������ �� �������� �����������
        }
    }
}