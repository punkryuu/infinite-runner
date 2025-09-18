using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 10;
    float velocidadLateral = 10;
    float fuerzaSalto = 600f;
    [SerializeField] LayerMask capaSuelo;
    [SerializeField] CapsuleCollider hitboxJugador;
    float fuerzaLateral = 45f;
    public Rigidbody rb;
    public float tiempoVelocidad = 0;
    public float tiempo = 0;
    float alturaOriginal ;
    float alturaAgache  ;
    public bool invulnerable;
    Vector3 centroOriginal;
    Vector3 centroAgache;
    float fuerzaChoque = 30f;

    void Start()
    {
        hitboxJugador = GetComponent<CapsuleCollider>();
        alturaOriginal = hitboxJugador.height;
        alturaAgache = alturaOriginal / 2;
        centroOriginal = hitboxJugador.center;
        centroAgache = centroOriginal - new Vector3(0 - (alturaOriginal - alturaAgache) / 2f, 0);
    }

    private void Update()
    {
        MovimientoLateral();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Agacharse();
        }     
    }
    void FixedUpdate()
    {
        if (!invulnerable)
        {
            Vector3 movimientoFrontal = transform.forward * velocidad;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movimientoFrontal.z);

            tiempo += Time.deltaTime;
            tiempoVelocidad += Time.deltaTime;
            ReducirVelocidad();
        }
    }
    void ReducirVelocidad()
    {
        if(velocidad <= 0)
        {
            return;
        }
        else if(tiempoVelocidad >= 5.0 )
        {
            velocidad = velocidad - 1;
            tiempoVelocidad = 0;
        }
    }
    IEnumerator invulnerabilidad()
    {
        invulnerable = true;
        yield return new WaitForSeconds(1f);

        Debug.Log("invulnerable");

        invulnerable = false;

    }
    public void Choque() 
    {

        if (!invulnerable)
        {
            GameManager.instancia.restarSobredosis();
            Vector3 direccionChoque = -transform.forward * velocidad/2; // con la velocidad creo que queda más natural 
            rb.AddForce(direccionChoque, ForceMode.Impulse);
            StartCoroutine(invulnerabilidad());
        }
    }
    void MovimientoLateral()
    {

         float direccion = Input.GetAxis("Horizontal"); //Pillar el movimiento del Jugador
         Vector3 velocidadLateral = rb.velocity;
         velocidadLateral.x = direccion * fuerzaLateral;
         rb.velocity = velocidadLateral;
        
    }
    void Saltar()
    {
        float altura = GetComponent<Collider>().bounds.size.y;
        bool tocaSuelo = Physics.Raycast(transform.position, Vector3.down, altura / 2 + 0.1f, capaSuelo);
        if (tocaSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto);
        }
    }
    IEnumerator tiempoAgachado()
    {
        yield return new WaitForSeconds(1f);
        hitboxJugador.height = alturaOriginal;
        hitboxJugador.center = centroOriginal;
        Debug.Log("Me Subo");
    }
    void Agacharse()
    {
        hitboxJugador.height = alturaAgache;
        hitboxJugador.center = centroAgache;
        Debug.Log("Me agacho");
        StartCoroutine(tiempoAgachado());              
    }   
}
