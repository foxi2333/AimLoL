using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // ��������� ������'�
    public Text DamageTxt;
    public GameObject TextObj;
    public AudioSource audioSource;
    public AudioClip SoundeOfHit;


 

    // ����� ��� ��������� ������'�
    public void TakeDamage(float damage)

    {
        {
            // ���������� AudioSource
            audioSource = GetComponent<AudioSource>();

            health -= damage; // �������� ������'�
            TextObj.SetActive(true); // �������� ��������� ��'���
            DamageTxt.text = "HP: " + health.ToString("0.0"); // ��������� ����� �� �������� ������'��

            if (audioSource != null)
            {
                audioSource.PlayOneShot(SoundeOfHit, 0.7F);
            }
            // ���� ������'� ����� ��� ���� ����, ������� ��'���
            if (health <= 0)
            {
                Destroy(gameObject); // ������� ��'��� ����������
            }


            

        }
    
    }
}
