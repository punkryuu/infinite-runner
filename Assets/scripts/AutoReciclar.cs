using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReciclar : MonoBehaviour
{
    Reciclador pool;       
    Transform jugador;
    float distanciaAtras = 30f;

    public void SetJugador(Transform j)
    {
        jugador = j;
    }

    public void SetPool(Reciclador p)
    {
        pool = p;
    }

    void Update()
    {
        if (jugador != null && transform.position.z < jugador.position.z - distanciaAtras)
        {
            pool.Return(gameObject);
        }
    }
}
