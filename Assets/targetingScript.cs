using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // Первая и вторая точки перемещения
    public Vector3 pointA = new Vector3(-3.16f, 0.77f, 4.91f);
    public Vector3 pointB = new Vector3(-7.17f, 0.77f, 4.91f);

    // Скорость движения
    public float speed = 2f;

    // Флаг направления движения
    private bool movingToB = true;

    void Update()
    {
        // Определяем текущую и целевую точку
        Vector3 target = movingToB ? pointB : pointA;

        // Двигаем объект к целевой точке
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Проверяем, достиг ли объект целевой точки
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            // Меняем направление движения
            movingToB = !movingToB;
        }
    }
}
