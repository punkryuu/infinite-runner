using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class generadorDeElementos : MonoBehaviour {
    [SerializeField] GameObject elemento;
    [SerializeField] Transform jugador;
    [SerializeField] GameObject obstaculo;
    float distanciaSpawn = 100f;
    float separacionZ = 50f;
    float[] lineasX = { -9f,0, 9f };
    float proximoSpawnZ = 200f;
    void Start()
    {
        GeneradorElementos(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.position.z + distanciaSpawn >= proximoSpawnZ)
        {
            GeneradorElementos(proximoSpawnZ);
            float separacionAleatoria = Random.Range(50f, 150f);
            proximoSpawnZ += separacionAleatoria;
        }
    }

    public void GeneradorElementos(float zPos)
    {
        int carrilLibre = Random.Range(0, lineasX.Length);
        for (int i = 0; i < lineasX.Length; i++)
        {
            Vector3 spawnPos = new Vector3(lineasX[i], 1f, zPos);

            if (i == carrilLibre)
            {
                //elemento o  vacío
                if (Random.value > 0.5f)
                {
                    Instantiate(elemento, spawnPos, Quaternion.identity);
                }
            }
            else
            {
                //  obstáculo o elemento
                if (Random.value > 0.5f)
                {
                    Instantiate(obstaculo, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(elemento, spawnPos, Quaternion.identity);
                }
            }

        }
    }


    /*
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),//pilla un punto dentro de los bounds del collider
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);//no es realmente necesario pues solo tomamos puntos dentro del collider como ya hicimos arriba pero para asegurarme
        }

        point.y = 1;
        return point;

    }
    */
}
