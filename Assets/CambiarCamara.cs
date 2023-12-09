using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CambiarCamara : MonoBehaviour
{
    private bool Unasolavez = true;
    [Header("Cambios de Cámara")]
    [SerializeField] private CinemachineVirtualCamera Cámara;
    [SerializeField] private GameObject PuntoObjetivo;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && Unasolavez)
        {
            Cámara.Follow = PuntoObjetivo.transform;
        }
    }
}
