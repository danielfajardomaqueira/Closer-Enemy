using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // M�todo para inicializar la posici�n aleatoria del enemigo
    void Start()
    {
        SetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para establecer una posici�n aleatoria
    public void SetRandomPosition()
    {
        float x = Random.Range(-10f, 10f); //Ajusta seg�n el tama�o de tu escena
        float y = Random.Range(-5f, 5f);
        transform.position = new Vector2(x, y);
    }
}
