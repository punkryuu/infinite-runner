using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminoInfinito : MonoBehaviour
{
    public Transform player;
    public GameObject segmentoPrefab; 
    public float longitudCamino = 50f; 
    public int segmentosIniciales = 5;

    private Queue<GameObject> segmentos = new Queue<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            if (segmentos.Count == 0)
            {
                Debug.Log("No se está creado");
                return;
            }
               
            // Remove the oldest segment
            GameObject viejo = segmentos.Dequeue();
            Destroy(viejo);
            Vector3 nuevaPos = segmentos.Peek().transform.position + new Vector3(0, 0, longitudCamino);
            GameObject nuevo = Instantiate(segmentoPrefab, nuevaPos, Quaternion.identity);
            segmentos.Enqueue(nuevo);
        }
    }  
    
    // Update is called once per frame
    void Update()
    {

    }
}


