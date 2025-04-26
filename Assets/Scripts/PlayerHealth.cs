using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public Slider hpSlider;
    public GameManager gameManager;  // Посилання на GameManager

    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;

        // Перевірка, чи є посилання на GameManager
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned!");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        hpSlider.value = currentHP;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameManager != null)
        {
            Debug.Log("Player is Dead!");
            gameManager.GameOver();  // Викликаємо GameOver() тільки, якщо gameManager не null
        }
        else
        {
            Debug.LogError("GameManager is null in Die method!");
        }
    }
}
