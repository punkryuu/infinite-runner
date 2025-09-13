using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int indicadorSobredosis;
    public int IndicadorSobredosis {get;set;}
    public static GameManager instancia;

    public void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
