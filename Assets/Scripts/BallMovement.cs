using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;    // Начальная скорость мяча
    public float extraSpeed;    // Дополнительная скорость при ударах
    public float maxExtraspeed; // Максимальная дополнительная скорость

    public bool player1Start = true; // Определяет, кто начнет игру

    private int hitCounter = 0;  // Количество ударов
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = Vector2.zero;       // Останавливаем мяч
        transform.position = Vector2.zero; // Возвращаем мяч в центр поля
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1); // Небольшая задержка перед стартом

        // Генерация случайного угла для начальной траектории мяча
        float randomAngle = Random.Range(-45f, 45f); // Случайный угол в диапазоне [-45, 45]

        // Определение направления движения в зависимости от того, кто начинает
        Vector2 direction;
        if (player1Start)
        {
            // Мяч летит влево с случайным вертикальным отклонением
            direction = new Vector2(-1, Mathf.Tan(randomAngle * Mathf.Deg2Rad));
        }
        else
        {
            // Мяч летит вправо с случайным вертикальным отклонением
            direction = new Vector2(1, Mathf.Tan(randomAngle * Mathf.Deg2Rad));
        }

        // Запускаем мяч
        MoveBall(direction);
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;  // Нормализуем вектор направления

        float ballSpeed = startSpeed + hitCounter * extraSpeed;  // Скорость мяча

        rb.velocity = direction * ballSpeed;  // Применяем скорость к мячу
    }

    public void IncreaseHitCounter()
    {
        // Увеличиваем счетчик ударов, если еще не достигли максимальной скорости
        if (hitCounter * extraSpeed < maxExtraspeed)
        {
            hitCounter++;
        }
    }
}
