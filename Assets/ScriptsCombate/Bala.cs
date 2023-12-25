using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 10;
    [SerializeField] private float daño = 4;
    [SerializeField] private string[] TagObjetivo;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < TagObjetivo.Length; i++)
            {
                if (other.CompareTag(TagObjetivo[i]))
                {
                    if (other.CompareTag("Enemigo"))
                    {
                        other.GetComponent<Estadisticas_Enemigos>().Recibir_Daño(daño);
                        Destroy(gameObject);
                    }
                    else if (other.CompareTag("JefeNivel"))
                    {
                        other.GetComponent<QuimperCombate>().Recibir_Daño(daño);
                        Destroy(gameObject);
                    }
                    else if (other.CompareTag("Jugador"))
                    {
                        other.GetComponent<Estadisticas_jugador>().Recibir_Daño(daño);
                        Destroy(gameObject);
                    }
                }
            }
        }
        
    }
}
