using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocarMujer : MonoBehaviour
{
    public bool tocaMujer = false;
    private string playerTag = "Player";
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag)) 
        {
            tocaMujer = true;
            Debug.Log("Choscaste wey");
        }
    }
}
