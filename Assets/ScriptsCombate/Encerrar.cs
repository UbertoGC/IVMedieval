using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Encerrar : MonoBehaviour
{
    private bool Unasolavez = true;
    [Header("Área a Cerrar")]
    [SerializeField] private GameObject ÁreaCambiable;
    private void Start()
    {
        ÁreaCambiable.GetComponent<TilemapCollider2D>().enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && Unasolavez)
        {
            ÁreaCambiable.GetComponent<TilemapCollider2D>().enabled = true;
            Unasolavez = false;
        }
    }
}
