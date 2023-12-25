using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Jugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento de Jugador")]
    float MovimientoHorizontal = 0f;
    [SerializeField] private float VelocidadDeMovimiento;
    [SerializeField] private float suavizado_de_movimiento;

    private Vector3 velocidad = Vector3.zero;
    private bool mirando_derecha = true;
    public InteraccionControles EntradasAcciones;

    [Header("Salto")]
    [SerializeField] private float FuerzaDeSalto;
    [SerializeField] private LayerMask QueEsSuelo;
    [SerializeField] private Transform ControladorSuelo;
    [SerializeField] private Vector3 DimensionesCaja;
    [SerializeField] private bool EnSuelo;
    private bool Salto;

    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        EntradasAcciones = new InteraccionControles();
    }
    private void OnEnable()
    {
        EntradasAcciones.Enable();
    }
    private void OnDisable()
    {
        EntradasAcciones.Disable();
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoHorizontal = EntradasAcciones.Interaccion.Horizontal.ReadValue<float>() * VelocidadDeMovimiento;
        if (EntradasAcciones.Interaccion.Salto.ReadValue<float>() != 0)
        {
            Salto = true;
        }
    }
    public void DetenerMovimiento()
    {
        animator.SetFloat("Horizontal", 0);
        rb2D.velocity = Vector3.zero;
    }
    private void FixedUpdate()
    {
        EnSuelo = Physics2D.OverlapBox(ControladorSuelo.position, DimensionesCaja, 0f, QueEsSuelo);
        animator.SetFloat("Horizontal", Mathf.Abs(MovimientoHorizontal));
        Mover(MovimientoHorizontal * Time.fixedDeltaTime, Salto);
        Salto = false;
    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizado_de_movimiento);
        if(mover > 0 && !mirando_derecha)
        {
            Girar();
        }else if(mover <0 && mirando_derecha)
        {
            Girar();
        }
        if(EnSuelo && saltar)
        {
            EnSuelo = false;
            rb2D.AddForce(new Vector2(0f, FuerzaDeSalto));
        }
    }
    private void Girar()
    {
        mirando_derecha = !mirando_derecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ControladorSuelo.position, DimensionesCaja);
    }
}
