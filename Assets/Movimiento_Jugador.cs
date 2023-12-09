using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Jugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento de Jugador")]
    float movimientoHorizontal = 0f;
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
    private bool Salto;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidad_de_movimiento;
        animator.SetFloat("Horizontal",Mathf.Abs(movimientoHorizontal));
        if (Input.GetButtonDown("Jump"))
        {
            Salto = true;
        }
    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimesionesCaja, 0f, queesSuelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime, Salto);
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
        if(enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzadeSalto));
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
        Gizmos.DrawWireCube(controladorSuelo.position, dimesionesCaja);
    }
}
