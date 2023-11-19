using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 10;
    public float minDistanceFromPlayer = 2f;
    public float maxDistanceFromPlayer = 15f; // Nueva variable para la distancia máxima

    void Start()
    {
        InstantiateEnemies();
    }

    void InstantiateEnemies()
    {
        Vector2 playerPosition = new Vector2(0f, 0f);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomPosition = GetRandomPosition(playerPosition, minDistanceFromPlayer, maxDistanceFromPlayer);
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomPosition(Vector2 playerPosition, float minDistance, float maxDistance)
    {
        Vector2 randomPosition = playerPosition;

        while (Vector2.Distance(randomPosition, playerPosition) < minDistance ||
               Vector2.Distance(randomPosition, playerPosition) > maxDistance)
        {
            float x = Random.Range(-maxDistance, maxDistance); // Ajusta según el tamaño de tu área
            float y = Random.Range(-maxDistance, maxDistance);
            randomPosition = new Vector2(x, y);
        }

        return randomPosition;
    }
}
