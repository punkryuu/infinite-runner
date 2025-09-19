using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoMuerte;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instancia.indicadorSobredosis >= 5)
        {
            textoMuerte.text = "Perdiste xd" ;
        }
    }
}
