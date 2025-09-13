using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSegmento : MonoBehaviour
{
    //código para llamar al trigger del segmento basicamente
    [SerializeField] CaminoInfinito camino;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camino.CrearSegmento(transform.gameObject);
        }
    }
}
