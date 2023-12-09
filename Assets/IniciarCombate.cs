using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IniciarCombate : MonoBehaviour
{
    private bool Unasolavez = true;
    [Header("Jefe")]
    [SerializeField] private QuimperCombate Jefe;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && Unasolavez)
        {
            Jefe.IniciarCombate();
            Unasolavez = false;
            this.enabled = false;
        }
    }
}
