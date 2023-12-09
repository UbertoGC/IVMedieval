using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJefe : MonoBehaviour
{
    [Header("Jefe")]
    [SerializeField] private int NumeroDe¡rea;
    [SerializeField] private bool ConGiro = false;
    [SerializeField] private QuimperCombate Jefe;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JefeNivel1") && Jefe.EnCombate)
        {
            Jefe.Atacando = true;
            Jefe.Moviendose = false;
            Jefe.Ubicacion = NumeroDe¡rea;
            Jefe.TiempoParaMoverse = 10f;
            Jefe.movimientoHorizontal = 0f;
            Jefe.Salto = false;
            if (ConGiro)
            {
                ConGiro = true;
                Jefe.Girar();
            }
        }
    }
}
