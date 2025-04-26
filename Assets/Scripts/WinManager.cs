using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public Text timerText;           // Текст для таймера
    public GameObject winPanel;      // Панель перемоги
    public Text winTimeText;         // Текст з часом на панелі перемоги

    private float timer = 0f;
    private bool isGameActive = true;

    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        }

        CheckWinCondition();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void CheckWinCondition()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && isGameActive)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        isGameActive = false;
        winPanel.SetActive(true);
        winTimeText.text = "Час проходження: " + timerText.text;
        Time.timeScale = 0f; // Пауза
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Знімаємо паузу
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезавантажуємо поточну сцену
    }

}