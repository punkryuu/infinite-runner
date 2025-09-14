using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostaculo : MonoBehaviour
{
    string playerTag = "Player";
    Vector3 direccionChoque;
    Vector3 direccionMovimiento;
    Movimiento movimientoJugador;
    
    void Start()
    {
     GameObject jugador = GameObject.FindGameObjectWithTag(playerTag);
      if (jugador != null)
      {
        movimientoJugador = jugador.GetComponent<Movimiento>();
       
      }
        
    }
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Chocaste");
        if (!other.gameObject.CompareTag(playerTag))
        {
            return;
        }
        Debug.Log("Chocaste con el jugador");
        movimientoJugador.Choque();

       

    }
}
