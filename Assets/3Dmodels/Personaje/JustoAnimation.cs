using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (mAnimator != null)
        {
            //Cambiar condiciones; si le ha dado a saltar, a rodar, etc... 

            if (true) //que se inicie al pulsar Jugar
                
            {//dura 2,4 segundos esta animacion (inicio correr) + loopCorrer  = 4,8
                mAnimator.SetBool("IsRunning", true); //Ya que en principio no se va a parar el personaje a menos que pierda, este estara activado hasta que pierda
            }

            if (false) //que se inicie al perder la partida
            {
                //dura 2,2 segundos esta animacion

                mAnimator.SetBool("Lose", true);
            }

            //Estas seran las acciones de Justo 

            if (false) //cuando pulse espacio
            {
                //dura 2,9 segundos esta animacion

                mAnimator.SetBool("Jump", true);

                //desactivar cuando toque suelo (imagino, no se como lo teneis configurado)

                mAnimator.SetBool("Jump", false);

            }

            if (false)  //detectar choque
            {
                mAnimator.SetBool("Splash", true);

                //desactivar quizas con deltaTime (dura 3 segundos esta animacion)

                mAnimator.SetBool("Splash", false);
            }


            if (false) //cuando pulse (tecla de rodar :D) )
            {
                mAnimator.SetBool("Roll", true); //desactivar quizas con deltaTime (dura 4,3 segundos esta animacion)
            }

            

        }
    }
}
