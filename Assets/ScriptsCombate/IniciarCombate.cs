using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IniciarCombate : MonoBehaviour
{
    private bool Unasolavez = true;

    [Header("Cambios de Cámara")]
    [SerializeField] private CinemachineVirtualCamera Cámara;
    [SerializeField] private GameObject PuntoObjetivo;
    [SerializeField] private AudioSource MusicaJefe;

    [Header("Jefe")]
    [SerializeField] private QuimperCombate Jefe;
    [SerializeField] private Interfaces ControlCinematica;
    [SerializeField] private Estadisticas_jugador JugadorEstadisticas;
    [SerializeField] private Movimiento_Jugador JugadorMovimiento;

    private AudioSource MusicaInicial;
    private float Espera = 4;
    private bool IniciarContador = false;
    private bool Presentacion = true;
    // Start is called before the first frame update
    private void Start()
    {
        MusicaInicial = Cámara.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (IniciarContador)
        {
            JugadorEstadisticas.enabled = false;
            JugadorMovimiento.enabled = false;
            Espera-= Time.deltaTime;
            if(Espera <= 2 && Presentacion) {
                Jefe.Presentacion();
                Presentacion = false;
            }
            if (Espera <= 0)
            {
                IniciarContador = false;
                ControlCinematica.ActivarSiguienteCinematica();
                Jefe.IniciarCombate();
                JugadorEstadisticas.enabled = true;
                JugadorMovimiento.enabled = true;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    public void FinCombate()
    {
        MusicaInicial.Play();
        MusicaJefe.Stop();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && Unasolavez)
        {
            MusicaInicial.Stop();
            MusicaJefe.Play();
            Cámara.Follow = PuntoObjetivo.transform;
            IniciarContador = true;
            JugadorMovimiento.DetenerMovimiento();
            Unasolavez = false;
        }
    }
}
