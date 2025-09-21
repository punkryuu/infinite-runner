using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovimientoMujer : MonoBehaviour
{
    public Transform jugador;  
    public float velocidad = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        if (jugador != null)
        {
            Vector3 direction = jugador.position - transform.position;
            float distance = direction.magnitude;
            Vector3 move = direction.normalized * velocidad * Time.deltaTime;
            transform.position += move;
            
        }
    }
}
