using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtenible : MonoBehaviour
{
    string playerTag = "Player";
    public float velocidadRotamiento = 90f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velocidadRotamiento * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chocaste");
        if(!other.gameObject.CompareTag (playerTag))
        { 
            return; 
        }
        Debug.Log("Chocaste con el jugador");
        GameManager.instancia.sumarSobredosis();

        Destroy(gameObject); //temporal, mejor desactivar el objeto para mayor eficiencia si podemos :)
    }
}
