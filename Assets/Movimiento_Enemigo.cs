using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Enemigo : MonoBehaviour
{
    [Header("Movimiento de Enemigo")]

    [SerializeField] private int Tipo;
    [SerializeField] private float Distancia;
    [SerializeField] private float Velocidad;
    [SerializeField] private Transform ControladorSuelo;
    private Vector3 velocidad = Vector3.zero;
    private bool mirando_derecha = true;
    private bool MovimientoDerecha = true;
    private Animator animator;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    
}
