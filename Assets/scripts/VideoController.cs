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
    public VideoPlayer reproductorCinematica3;
    public VideoPlayer reproductorCinematica4;
    public VideoPlayer reproductorCinematica5;

    public RawImage cargaCinematica;
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
            case 3:
                cargaCinematica.gameObject.SetActive(true);
                reproductorCinematica3.Play();
                reproductorCinematica3.loopPointReached += TerminaCinematica;
                break;
            case 4:
                cargaCinematica.gameObject.SetActive(true);
                reproductorCinematica4.Play();
                reproductorCinematica4.loopPointReached += TerminaCinematica;
                break;
            case 5:
                cargaCinematica.gameObject.SetActive(true);
                reproductorCinematica5.Play();
                reproductorCinematica5.loopPointReached += TerminaCinematica;
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
    public void BotonCinematica3()
    {

        if (GameManager.instancia.contadorMuerte >= 3 && VideoManager.instancia.cinematica1Vista)
        {
            VideoManager.instancia.numeroCinematica = 3;
            SceneManager.LoadScene("Reproductor");
        }
    }
    public void BotonCinematica4()
    {
        if (GameManager.instancia.contadorMuerte >= 4 && VideoManager.instancia.cinematica2Vista)
        {
            VideoManager.instancia.numeroCinematica = 4;
            SceneManager.LoadScene("Reproductor");
        }
    }
    public void BotonCinematica5()
    {
        if (GameManager.instancia.contadorMuerte == 5 && VideoManager.instancia.cinematica2Vista)
        {
            VideoManager.instancia.numeroCinematica = 5;
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
