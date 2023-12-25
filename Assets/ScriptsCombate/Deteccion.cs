using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    public Animator animator;
    public Estadisticas_Enemigos enemigo;
    private void Start()
    {
        animator = enemigo.GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador")){
            animator.SetBool("Traslado", false);
            enemigo.atacando = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Jugador")){

            enemigo.atacando = false;
            enemigo.TiempoEspera = 0.5f;
        }
    }
}
