using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minDistance = 2f;
    public Color highlightColor = Color.red;
    public Color originalColor = Color.white; // Color original del enemigo

    private GameObject closestEnemy = null; // Variable para almacenar el enemigo más cercano

    private void Update()
    {
        MovePlayer();
        CheckEnemyDistance();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    private void CheckEnemyDistance()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Restaura el color del enemigo anteriormente resaltado
        if (closestEnemy != null)
        {
            SetEnemyColor(closestEnemy, originalColor);
            closestEnemy = null;
        }

        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            // Actualiza el enemigo más cercano
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        // Cambia el color del enemigo más cercano
        if (closestEnemy != null && closestDistance < minDistance)
        {
            SetEnemyColor(closestEnemy, highlightColor);
        }
    }

    // Método para cambiar el color del enemigo
    private void SetEnemyColor(GameObject enemy, Color color)
    {
        SpriteRenderer enemyRenderer = enemy.GetComponent<SpriteRenderer>();
        if (enemyRenderer != null)
        {
            enemyRenderer.color = color;
        }
    }
}
