using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instancia;
    [SerializeField] TextMeshProUGUI textoMuerte;
    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderFill;

    public void Awake()//EL SINGLETON JAJJAJAJA
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
    void Start()
    {
        sliderFill.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instancia.IndicadorSobredosis >= 5)
        {
            textoMuerte.text = "Perdiste xd" ;
        }
    }
    public void ActivarSlider() 
    {
        if (!sliderFill.activeSelf)
        {
            sliderFill.SetActive(true);
        }
    }
    public void DesactivarSlider() 
    {
        if (slider.value <= 0)
        {
            sliderFill.SetActive(false);
        }
    }
    public void CambiarValorSlider(float valor) 
    {
        slider.value = valor;
    }
}
