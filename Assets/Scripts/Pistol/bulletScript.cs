using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip SoundeOfHit;
    public AudioSource audioSource;
    //public float PlayOneShot;
    public float damage = 20f;
    public float speed = 0.005f; // �������� ��� 
    public float lifeTime = 5f; // ��� �� �������� ���, ���� ���� �� ��������� � ��'���

    private Rigidbody rb;
  
    private void OnCollisionEnter(Collision collision)
    {
        print("print4");
        // ����������, �� �� ��'��� ����������
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(SoundeOfHit, 0.7F);
            print("print1");         // �������� ������ EnemyHealth � ��'����, � ���� �������� ��������
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            
            // ���� ������ ��������, ������� �����
            if (enemyHealth != null)
            {
                print("print2");
                enemyHealth.TakeDamage(damage);
            }

            // ������� ���� ���� ��������
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // �������� ��������� Rigidbody
        rb = GetComponent<Rigidbody>();


        // ��������� ���� ����� ������ ���, ���� ���� �� ��������� � ��'���
        Destroy(gameObject, lifeTime);

        // ������������ ��������� �������� ��� � �������� ������
        rb.velocity = transform.forward * speed;
    }

    
}
