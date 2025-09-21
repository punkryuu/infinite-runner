using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;

public class Reciclador : MonoBehaviour
{
    [SerializeField] GameObject [] prefabs;       // pewrefab que va a reciclar este pool
    [SerializeField] int cantidadInicial = 30;

    Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get(Vector3 pos)
    {
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            obj = Instantiate(prefab);
        }

        obj.transform.position = pos;
        return obj;
    }

    // Devolver al pool
    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
