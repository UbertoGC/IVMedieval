using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Encerrar : MonoBehaviour
{
    private bool Unasolavez = true;
    [Header("햞ea a Cerrar")]
    [SerializeField] private GameObject 햞eaCambiable;
    private void Start()
    {
        햞eaCambiable.GetComponent<TilemapCollider2D>().enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && Unasolavez)
        {
            햞eaCambiable.GetComponent<TilemapCollider2D>().enabled = true;
            Unasolavez = false;
        }
    }
}
