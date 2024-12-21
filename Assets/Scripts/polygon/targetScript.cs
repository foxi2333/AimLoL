using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Початкові та кінцеві координати
    public Vector3 startPosition = new Vector3(-3.972f, 0.507f, 4.91f);
    public Vector3 endPosition = new Vector3(-7.063f, 0.507f, 4.91f);

    // Швидкість переміщення (одиниць на секунду)
    public float moveSpeed = 2f;

    // Відстань між точками
    private float journeyLength;
    private float startTime;

    // Переміщення вперед чи назад
    private bool movingTowardsEnd = true;

    void Start()
    {
        // Ініціалізація початкових параметрів
        transform.position = startPosition; // Встановлюємо початкову позицію
        journeyLength = Vector3.Distance(startPosition, endPosition); // Вираховуємо відстань
        startTime = Time.time; // Записуємо час початку руху
    }

    void Update()
    {
        // Час, що пройшов з початку руху
        float distanceCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        if (movingTowardsEnd)
        {
            // Переміщуємо об'єкт по прямій лінії від startPosition до endPosition
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }
        else
        {
            // Переміщуємо об'єкт по прямій лінії від endPosition до startPosition
            transform.position = Vector3.Lerp(endPosition, startPosition, fractionOfJourney);
        }

        // Якщо об'єкт досягнув кінцевої точки, змінюємо напрямок
        if (fractionOfJourney >= 1f)
        {
            startTime = Time.time; // Оновлюємо час для нового циклу
            movingTowardsEnd = !movingTowardsEnd; // Змінюємо напрямок
        }
    }
}
