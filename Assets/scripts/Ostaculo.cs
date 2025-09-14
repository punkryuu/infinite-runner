using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostaculo : MonoBehaviour
{
    string playerTag = "Player";
    Vector3 direccionChoque;
    Vector3 direccionMovimiento;
    float fuerzaChoque = 3000f;
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
    IEnumerator invulnerabilidad()
    {
        movimientoJugador.invulnerable = true;
        yield return new WaitForSeconds(1f);
        
        Debug.Log("invulnerable");

        movimientoJugador.invulnerable=false;
        
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Chocaste");
        if (!other.gameObject.CompareTag(playerTag))
        {
            return;
        }
        Debug.Log("Chocaste con el jugador");

        if(!movimientoJugador.invulnerable)
        {
            GameManager.instancia.restarSobredosis();
            Vector3 direccionChoque = -transform.forward * movimientoJugador.velocidad * fuerzaChoque;
            movimientoJugador.rb.AddForce(direccionChoque, ForceMode.Impulse);
            StartCoroutine(invulnerabilidad());
        }
       

    }
}
