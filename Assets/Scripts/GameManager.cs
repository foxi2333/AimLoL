using UnityEngine;
using UnityEngine.SceneManagement;  // Для перезавантаження сцени
using UnityEngine.UI;  // Для роботи з UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Панель з текстом і кнопкою
    public Text gameOverText;         // Текст для повідомлення
    public Button restartButton;      // Кнопка для перезапуску сцени

    void Start()
    {
        // Зробимо панель невидимою на початку
        gameOverPanel.SetActive(false);

        // Приклад для кнопки: підписуємось на подію натискання кнопки
        restartButton.onClick.AddListener(RestartScene);
    }

    // Метод для виклику при смерті гравця
    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Показуємо панель "Game Over"
        gameOverPanel.SetActive(true);
        gameOverText.text = "You Died!";  // Змінюємо текст на панелі

        // Зупиняємо гру або робимо паузу (якщо хочеш)
        Time.timeScale = 0f;  // Остановка часу
    }

    // Метод для перезавантаження сцени
    public void RestartScene()
    {
        Time.timeScale = 1f;  // Відновлюємо час
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Перезавантажуємо поточну сцену
    }
}
