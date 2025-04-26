using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Необхідно для роботи з сценами

public class MainMenu : MonoBehaviour
{
    // Цей метод буде викликаний, коли гравець натискає кнопку "Start Game"
    public void StartGame()
    {
        // Завантажуємо сцену, яку хочемо використовувати для гри
        // Замініть "GameScene" на назву сцени вашої гри
        SceneManager.LoadScene("m4a4");
    }

    // Якщо хочеш додати кнопку для виходу з гри
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();  // Закриває гру
    }
}
