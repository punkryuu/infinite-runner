using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer reproductorCinematica1;
    public VideoPlayer reproductorCinematica2;
    public RawImage cargaCinematica;
    // Start is called before the first frame update
    
    void Start()
    {
            cargaCinematica.gameObject.SetActive(false);

            if (GameManager.instancia != null && GameManager.instancia.acabaDeMorir)
            {
                CasosMuerte(GameManager.instancia.contadorMuerte);
                GameManager.instancia.acabaDeMorir = false;
            }
             else if (VideoManager.instancia != null && VideoManager.instancia.numeroCinematica > 0)
            {
            
                CasosMuerte(VideoManager.instancia.numeroCinematica);
             VideoManager.instancia.numeroCinematica = 0; // reset
            }

    }



    void Update()
    {
        
    }

    public void CasosMuerte(int contadorMuerte)
    {

        switch (contadorMuerte)
        {
            case 1:
                cargaCinematica.gameObject.SetActive(true);
                reproductorCinematica1.Play();
                reproductorCinematica1.loopPointReached += TerminaCinematica;
                break;
            case 2:
                cargaCinematica.gameObject.SetActive(true);
                reproductorCinematica2.Play();
                reproductorCinematica2.loopPointReached += TerminaCinematica;
                break;
        }
    }

    public void BotonCinematica1()
    {
       
         if (GameManager.instancia.contadorMuerte >=1 && VideoManager.instancia.cinematica1Vista)
        {
            VideoManager.instancia.numeroCinematica = 1;
            SceneManager.LoadScene("Reproductor");
        }
    }
    public void BotonCinematica2()
    {
        if (GameManager.instancia.contadorMuerte >= 2 && VideoManager.instancia.cinematica2Vista)
        {
            VideoManager.instancia.numeroCinematica = 2;
            SceneManager.LoadScene("Reproductor");
        }
       
    }


    public void MostrarCinematica(VideoPlayer vid)
    {
        cargaCinematica.gameObject.SetActive(true);
        vid.Play();
        vid.loopPointReached += TerminaCinematica;
    }
    public void TerminaCinematica(VideoPlayer vid)
    {
        cargaCinematica.gameObject.SetActive(false);
        SceneManager.LoadScene("PantallaDeInicio");
        GameManager.instancia.escenaCargada = false;
    }
}
