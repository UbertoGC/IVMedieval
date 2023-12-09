using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    private Animator animator;
    [SerializeField]  private float vida = 50;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (vida <= 0){
            animator.SetBool("Estado",false);
        }
    }
}
