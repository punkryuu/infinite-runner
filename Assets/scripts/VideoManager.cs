using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer reproductor;
    public RawImage cargaCinematica1;
   
    private void Start()
    {
        cargaCinematica1.gameObject.SetActive(false);
        if (GameManager.instancia == null)
        {
            GameManager.instancia = FindObjectOfType<GameManager>();
        }
    
}
    public void BotonCinematica1()
    {
        if(GameManager.instancia.contadorMuerte >= 1)
        {
            cargaCinematica1.gameObject.SetActive(true);
            reproductor.Play();
            reproductor.loopPointReached += TerminaCinematica;
        }
    }
    void TerminaCinematica(VideoPlayer vid)
    {
        cargaCinematica1.gameObject.SetActive(false);
        SceneManager.LoadScene("PantallaDeInicio");
    }
    void BotonCreditos()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void BotonCinematicas()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
