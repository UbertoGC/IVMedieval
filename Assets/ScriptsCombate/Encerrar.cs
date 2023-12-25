using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Encerrar : MonoBehaviour
{
    private bool Unasolavez = true;
    [Header("�rea a Cerrar")]
    [SerializeField] private GameObject �reaCambiable;
    private void Start()
    {
        �reaCambiable.GetComponent<TilemapCollider2D>().enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && Unasolavez)
        {
            �reaCambiable.GetComponent<TilemapCollider2D>().enabled = true;
            Unasolavez = false;
        }
    }
}
