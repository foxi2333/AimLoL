using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // �������� ���
    public float lifeTime = 5f; // ��� �� �������� ���, ���� ���� �� ��������� � ��'���

    private Rigidbody rb;

    private void Start()
    {
        // �������� ��������� Rigidbody
        rb = GetComponent<Rigidbody>();


        // ��������� ���� ����� ������ ���, ���� ���� �� ��������� � ��'���
        Destroy(gameObject, lifeTime);

        // ������������ ��������� �������� ��� � �������� ������
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ��������, �� ��'���, � ���� ��������� ����, �� ������ � ������ �����
        //var healthScript = collision.gameObject.GetComponent<Health>();

       // if (healthScript != null)
       // {
            // ���� � ����� �����, ������� 10 �������
      //      healthScript.TakeDamage(10);
      //  }

        // � ����-����� ������� ������� ����
       // Destroy(gameObject);
    }
}
