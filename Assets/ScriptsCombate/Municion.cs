using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    [Header("Datos del Item")]
    [SerializeField] private int NúmeroDeBalasQueDa;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            other.GetComponent<Estadisticas_jugador>().AumentarBalas(NúmeroDeBalasQueDa);
            Destroy(gameObject);
        }
    }
}
