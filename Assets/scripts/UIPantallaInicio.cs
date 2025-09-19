using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIPantallaInicio : MonoBehaviour
{

    public void BotonJugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    /*
     * en cargar una escena tarda bastante es mejor mostrar y ocultar un panel
    void BotonOpciones()
    {
        SceneManager.LoadScene("SampleScene");
    }
    */
    void BotonCreditos()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BotonCinematicas()
    {
        SceneManager.LoadScene("Cinemáticas");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
