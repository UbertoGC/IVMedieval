using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Estadisticas_jugador : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float Vida = 24;
    [SerializeField] private Transform control_disparo;
    [SerializeField] private GameObject bala;
    private int pólvora = 10;
    private float daño_melee = 4;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Disparar();
        }
    }
    
    private void Disparar()
    {
        if(pólvora > 0) {
            Instantiate(bala, control_disparo.position, control_disparo.rotation);
            pólvora--;
        }
    }
    public void Recibir_Daño(float daño)
    {
        Vida -= daño;
        if (Vida <= 0)
        {
            animator.SetBool("Estado", false);
        }
    }
}
