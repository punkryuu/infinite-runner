using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class generadorDeElementos : MonoBehaviour
{
    public GameObject elemento;
    void Start()
    {
       // generadorElementos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generadorElementos()
    {
        int elementosAGenerar = Random.Range(0, 10);
        for (int i = 0; i < elementosAGenerar; i++)
        {
            GameObject temp = Instantiate(elemento);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

    }

    

    Vector3 GetRandomPointInCollider( Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),//pilla un punto dentro de los bounds del collider
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);//no es realmente necesario pues solo tomamos puntos dentro del collider como ya hicimos arriba pero para asegurarme
        }

        point.y = 1;
        return point;

    }
}
