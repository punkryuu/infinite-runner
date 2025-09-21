using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;


public class VideoManager : MonoBehaviour
{
    public static VideoManager instancia;
   
    public VideoManager videoManager;
    public bool cinematica1Vista = false;
    public bool cinematica2Vista = false;
    public bool cinematica3Vista = false;
    public bool cinematica4Vista = false;
    public bool cinematica5Vista = false;

    public int numeroCinematica = 0;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
}
    private void Start()
    {
        
        if (GameManager.instancia == null)
        {
            GameManager.instancia = FindObjectOfType<GameManager>();
        }
}
      
    public void DesbloquearCinematica()
    {
        if (GameManager.instancia.contadorMuerte >= 1) cinematica1Vista = true;
        else if (GameManager.instancia.contadorMuerte >= 2) cinematica2Vista = true;
        else if (GameManager.instancia.contadorMuerte >= 3) cinematica3Vista = true;
        else if (GameManager.instancia.contadorMuerte >= 4) cinematica4Vista = true;
        else if (GameManager.instancia.contadorMuerte == 5) cinematica2Vista = true;
    }


}
