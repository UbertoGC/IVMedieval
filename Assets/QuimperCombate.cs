using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuimperCombate : MonoBehaviour
{
    private bool UnaVez = true;
    private float vida = 40;
    private float daño_melee;
    public float TiempoParaMoverse = 10f;
    public int Ubicacion = 2;
    private bool ida = false;
    private Animator animator;
    private Rigidbody2D rb2D;

    [Header("Combate")]
    [SerializeField] private GameObject Bala;
    [SerializeField] private Transform ControlDisparo;
    private float VelocidadAtaque = 5.0f;
    private float CadenciaDisparo = 0.5f;
    public float TiempoEspera = 0.5f;
    public int ContadorAtaques = 3 ;

    [Header("Animacion de Muerte")]
    [SerializeField] private GameObject AnimacionMuerte;

    [Header("Movimiento de Jefe")]
    public float movimientoHorizontal = 0f;
    [SerializeField] private float velocidad_de_movimiento;
    [SerializeField] private float suavizado_de_movimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirando_derecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzadeSalto;
    [SerializeField] private LayerMask queesSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimesionesCaja;
    [SerializeField] private bool enSuelo;
    public bool Salto;

    [Header("Estados")]
    [SerializeField]  public bool EnCombate = false;
    [SerializeField]  public bool Atacando = false;
    [SerializeField] public bool Moviendose = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnCombate)
        {
            if (TiempoParaMoverse <= 0)
            {
                Moviendose = true;
                Atacando = false;
                UnaVez = true;
            }
            if (Atacando)
            {
                animator.SetBool("Traslado", false);
                movimientoHorizontal = 0f;
                if (TiempoEspera <= 0 && ContadorAtaques > 0)
                {
                    if(CadenciaDisparo <= 0)
                    {
                        Disparar();
                        CadenciaDisparo = 0.3f;
                        ContadorAtaques--;
                    }
                    else
                    {
                        CadenciaDisparo -= Time.deltaTime;
                    }
                }
                else if(TiempoEspera <= 0 && ContadorAtaques <= 0)
                {
                    TiempoEspera = VelocidadAtaque;
                    ContadorAtaques = 3;
                }
                else
                {
                    TiempoEspera -= Time.deltaTime;
                }
            }
            else if (Moviendose)
            {
                animator.SetBool("Traslado", true);
                if (Ubicacion == 1)
                {
                    ida = false;
                    movimientoHorizontal = 1f * velocidad_de_movimiento;
                    if (UnaVez)
                    {
                        Salto = true;
                        UnaVez = false;
                    }
                    
                }
                else if (Ubicacion == 2) {
                    if (ida)
                    {
                        movimientoHorizontal = -1f * velocidad_de_movimiento;
                    }
                    else
                    {
                        movimientoHorizontal = -1f * velocidad_de_movimiento;
                        if (UnaVez)
                        {
                            Salto = true;
                            UnaVez = false;
                        }
                    }
                }
                else if(Ubicacion == 3) {
                    ida = true;
                    movimientoHorizontal = 1f * velocidad_de_movimiento;
                }
            }
            TiempoParaMoverse -= Time.deltaTime;
        }
        
    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimesionesCaja, 0f, queesSuelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime, Salto);
        Salto = false;
    }
    public void IniciarCombate()
    {
        EnCombate = true;
        Atacando = true;
        Moviendose = false;
        Girar();
    }
    private void Disparar()
    {
        Instantiate(Bala, ControlDisparo.position, ControlDisparo.rotation);
    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizado_de_movimiento);
        if (mover > 0 && !mirando_derecha)
        {
            Girar();
        }
        else if (mover < 0 && mirando_derecha)
        {
            Girar();
        }
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzadeSalto));
        }
    }
    public void Girar()
    {
        mirando_derecha = !mirando_derecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    public void Recibir_Daño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            EnCombate = false;
            Muerte();
        }
    }
    private void Muerte()
    {
        animator.SetBool("Vida",false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimesionesCaja);
    }
}
