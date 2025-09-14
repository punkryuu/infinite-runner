using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CaminoInfinito : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField] private GameObject segmentoPrefab;
    [SerializeField] private float longitudCamino = 120f; //por ahora 120 va fino
    [SerializeField] private int segmentosIniciales = 5;
    private Queue<GameObject> segmentos = new Queue<GameObject>();
    string playerTag = "Player";
    private void Start()
    {
        Vector3 posicion = segmentoPrefab.transform.position;
        for (int i = 0; i < segmentosIniciales; i++)
        {
            GameObject segmento = Instantiate(segmentoPrefab, posicion, Quaternion.identity);
            segmentos.Enqueue(segmento);
            posicion += new Vector3(0, 0, longitudCamino);
        }
    }
   
    //ahora se llama al trigger enter desde el prefab 
    public void CrearSegmento(GameObject segmento)
    {             
           
            GameObject viejo = segmentos.Dequeue();
            //reciclamos el segmento viejo poniendolo delante
            Vector3 nuevaPos = segmentos.Last().transform.position + new Vector3(0, 0, longitudCamino);
        viejo.transform.position = nuevaPos;
        segmentos.Enqueue(viejo);       
    }  
    
    // Update is called once per frame
    void Update()
    {

    }
}


