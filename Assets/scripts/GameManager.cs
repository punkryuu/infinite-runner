using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    UIManager uiManager; 
    private int indicadorSobredosis;
    public int IndicadorSobredosis {get;set;}
    [SerializeField] Material material;//el material de distorsion con el shader
    string fuerzaDistorsion = "_FuerzaDistorsion";//metemos la variable que vamos a ajustar en un string para                                                //no tener que ver si la escribimos correctamente
    float cantidadAOperar = 0.0025f;//cantidad que sumamos/restamos
    //(es bastante grande pero bueno es jugar con los números)
    float maximaDistorsion = 1;//máximo(se puede cambiar pero ya es muchisimo)
    float minimaDistorsion = 0; //minimo (no se que puede llegar a pasar si baja del cero)
    public int contadorMuerte = 0;
    public bool escenaCargada = false;
    public bool acabaDeMorir = false;
    public ChocarMujer chocarMujer;
    public AudioSource sonidoBeber;

    public void Awake()
    {
        if(instancia == null)
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
        if (material != null) material.SetFloat(fuerzaDistorsion, minimaDistorsion);
        else { Debug.Log("se te olvido poner el material en el gamemanager ma g"); }
        indicadorSobredosis = 0;
        uiManager = UIManager.instancia;
        chocarMujer = FindObjectOfType<ChocarMujer>();
        SceneManager.activeSceneChanged += ChangedActiveScene;

    }
    private void ChangedActiveScene(Scene current, Scene next) 
    { 
        if (material != null) material.SetFloat(fuerzaDistorsion, minimaDistorsion);
    }
    void Update()
    {
       RegistrarMuerte();
    }
    public void sumarSobredosis() 
    {
        indicadorSobredosis++;
        sonidoBeber.PlayOneShot(sonidoBeber.clip);
        if (material != null)
        {
            if (material.GetFloat(fuerzaDistorsion) < maximaDistorsion)//si ya esta en el maximo es tomteria
                                                                       //hacer la operacion
            {
                float resultado = material.GetFloat(fuerzaDistorsion) + cantidadAOperar;//cogemos el valor
                                                                                        //d la variable y le sumamos 
                //Mathf.Clamp(resultado, minimaDistorsion, maximaDistorsion);// lo clampeamos al máximo si hace falta
                material.SetFloat(fuerzaDistorsion, resultado);//lo aplicamos al material
                uiManager.ActivarSlider();
                float valorSlider = indicadorSobredosis;
                uiManager.CambiarValorSlider(valorSlider);
                
            }
        }
        
        else { Debug.Log("se te olvido poner el material en el gamemanager ma g"); }
    }
    //esto es para que no se vea todo distorsionado en el editor cuando cerramos el juego
    private void OnApplicationQuit()
    {
        if (material != null) material.SetFloat(fuerzaDistorsion, minimaDistorsion);
    }
    public void restarSobredosis()
    {
        indicadorSobredosis--;
        if (material != null)
        {
            if (material.GetFloat(fuerzaDistorsion) < minimaDistorsion)//si ya esta en el minimo es tomteria
                                                                       //hacer la operacion
            {
                float resultado = material.GetFloat(fuerzaDistorsion) - cantidadAOperar;//cogemos el valor
                                                                                        //d la variable y le restamos
                //Mathf.Clamp(resultado, minimaDistorsion, maximaDistorsion);// lo clampeamos al máximo si hace falta
                material.SetFloat(fuerzaDistorsion, resultado);//lo aplicamos al material
                uiManager.DesactivarSlider();
                float valorSlider = indicadorSobredosis;
                uiManager.CambiarValorSlider(valorSlider);
            }
            
        }
    }  
    public void RegistrarMuerte()
    {
        if (!escenaCargada && (indicadorSobredosis >= 5 || (chocarMujer != null && chocarMujer.tocaMujer))
)
        {
            escenaCargada = true; 
            contadorMuerte++; 
            acabaDeMorir = true;
            if (chocarMujer != null)
            {
                chocarMujer.tocaMujer = false;
            }            
            VideoManager.instancia.DesbloquearCinematica();
            SceneManager.LoadScene("Reproductor");
            indicadorSobredosis = 0;
        }
    }

}
