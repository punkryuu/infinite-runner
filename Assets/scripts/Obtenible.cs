using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtenible : MonoBehaviour
{
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
        //if (other.gameObject.GetComponent<Obstaculo>() != null )
        {
            Destroy(gameObject);
            return;
        }
        if(other.gameObject.name != "Player")
        { 
            return; 
        }

        GameManager.instancia.indicadorSobredosis++;

        Destroy(gameObject); //temporal, mejor desactivar el objeto para mayor eficiencia si podemos :)
    }
}
