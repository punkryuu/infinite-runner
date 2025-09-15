using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int indicadorSobredosis;
    public int IndicadorSobredosis {get;set;}
    [SerializeField] Material material;//el material de distorsion con el shader
    string fuerzaDistorsion = "_FuerzaDistorsion";//metemos la variable que vamos a ajustar en un string para
                                                  //no tener que ver si la escribimos correctamente
    float cantidadAOperar = 0.005f;//cantidad que sumamos/restamos

    //(es bastante grande pero bueno es jugar con los números)
    float maximaDistorsion = 1;//máximo(se puede cambiar pero ya es muchisimo)
    float minimaDistorsion = 0; //minimo (no se que puede llegar a pasar si baja del cero)
    public static GameManager instancia;

    public void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        if (material != null) material.SetFloat(fuerzaDistorsion, minimaDistorsion);
        else { Debug.Log("se te olvido poner el material en el gamemanager ma g"); }
    }

        // Update is called once per frame
    void Update()
    {
        
    }
    public void sumarSobredosis() 
    {
        indicadorSobredosis++;
        if (material != null)
        {
            if (material.GetFloat(fuerzaDistorsion) < maximaDistorsion)//si ya esta en el maximo es tomteria
                                                                       //hacer la operacion
            {
                float resultado = material.GetFloat(fuerzaDistorsion) + cantidadAOperar;//cogemos el valor
                                                                                        //d la variable y le sumamos 
                Mathf.Clamp(resultado, minimaDistorsion, maximaDistorsion);// lo clampeamos al máximo si hace falta
                material.SetFloat(fuerzaDistorsion, resultado);//lo aplicamos al material
            }
        }
        else { Debug.Log("se te olvido poner el material en el gamemanager ma g"); }
    }
    public void restarSobredosis()
    {
        indicadorSobredosis--;
        if (material != null)
        {
            if (material.GetFloat(fuerzaDistorsion) > minimaDistorsion)//si ya esta en el minimo es tomteria
                                                                       //hacer la operacion
            {
                float resultado = material.GetFloat(fuerzaDistorsion) - cantidadAOperar;//cogemos el valor
                                                                                        //d la variable y le sumamos 
                Mathf.Clamp(resultado, minimaDistorsion, maximaDistorsion);// lo clampeamos al máximo si hace falta
                material.SetFloat(fuerzaDistorsion, resultado);//lo aplicamos al material
            }
        }
        else { Debug.Log("se te olvido poner el material en el gamemanager ma g"); }
    }
    //esto es para que no se vea todo distorsionado en el editor cuando cerramos el juego
    //esto es para que no se vea todo distorsionado en el editor cuando cerramos el juego
    private void OnApplicationQuit()
    {
        if (material != null) material.SetFloat(fuerzaDistorsion, minimaDistorsion);
    }
}
