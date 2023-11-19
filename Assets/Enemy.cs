using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Método para inicializar la posición aleatoria del enemigo
    void Start()
    {
        SetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para establecer una posición aleatoria
    public void SetRandomPosition()
    {
        float x = Random.Range(-10f, 10f); //Ajusta según el tamaño de tu escena
        float y = Random.Range(-5f, 5f);
        transform.position = new Vector2(x, y);
    }
}
