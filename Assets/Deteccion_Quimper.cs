using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion_Quimper : MonoBehaviour
{
    public Animator animator;
    public QuimperCombate Jefe;
    // Start is called before the first frame update
    void Start()
    {
        animator = Jefe.GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            animator.SetBool("Traslado", false);
            Jefe.Atacando = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {

            Jefe.Atacando = false;
            Jefe.TiempoEspera = 0.5f;
        }
    }
}
