using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour
{
    public float racketSpeed;  // Скорость движения ракетки
    public GameObject ball;    // Ссылка на мяч
    public float followThreshold = 0.2f; // Порог для движения (меньше этого значения - не двигаться)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Находим позицию мяча
        float ballY = ball.transform.position.y;

        // Вычисляем разницу между позицией мяча и ракетки
        float directionY = ballY - transform.position.y;

        // Если разница больше заданного порога, ракетка начнёт движение
        if (Mathf.Abs(directionY) > followThreshold)
        {
            // Нормализуем направление, чтобы скорость оставалась постоянной
            rb.velocity = new Vector2(0, Mathf.Sign(directionY)) * racketSpeed;
        }
        else
        {
            // Останавливаем ракетку, если мяч рядом
            rb.velocity = Vector2.zero;
        }
    }
}
