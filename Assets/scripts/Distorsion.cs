using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


//para que funcione hay que añadir un Full Screen Pass Renderer Feature al renderer que estemos utilizando
//(creo que aparece en la cámara pero el por defecto es el high fidelity),
//asiganrle el material y activar (en el archivo que se llama igual pero no pone -renderer al final) opaque textures
public class Distorsion : MonoBehaviour
{
    //codigo que voy a aplicar a botones pero que en principio se puede
    //aplicar en cualquier código que se use el material

    [SerializeField] Material material;//el material de distorsion con el shader

    string fuerzaDistorsion = "_FuerzaDistorsion";//metemos la variable que vamos a ajustar en un string para
                                                  //no tener que ver si la escribimos correctamente

    float cantidadAOperar = 0.1f;//cantidad que sumamos/restamos

                                 //(es bastante grande pero bueno es jugar con los números)
    float maximaDistorsion = 1;//máximo(se puede cambiar pero ya es muchisimo)

    float minimaDistorsion = 0; //minimo (no se que puede llegar a pasar si baja del cero)
    public void restarDistorsion() 
    {
        if (material.GetFloat(fuerzaDistorsion) > minimaDistorsion) //si ya esta en el minimo es tomteria
                                                                    //hacer la operacion
        {
            float resultado = material.GetFloat(fuerzaDistorsion)- cantidadAOperar; //cogemos el valor
                                                                                    // de la variable y le restamos 
            Mathf.Clamp(resultado, minimaDistorsion, maximaDistorsion); // lo clampeamos al minimo si hace falta
            material.SetFloat(fuerzaDistorsion, resultado);//lo aplicamos al material
        }
    }
    public void sumarDistorsion()
    {
        if (material.GetFloat(fuerzaDistorsion) < maximaDistorsion)//si ya esta en el maximo es tomteria
                                                                   //hacer la operacion
        {
            float resultado = material.GetFloat(fuerzaDistorsion) + cantidadAOperar;//cogemos el valor
                                                                                    //d ela variable y le sumamos 
            Mathf.Clamp(resultado, minimaDistorsion, maximaDistorsion);// lo clampeamos al máximo si hace falta
            material.SetFloat(fuerzaDistorsion, resultado);//lo aplicamos al material
        }
    }


}
