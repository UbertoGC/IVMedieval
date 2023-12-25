using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo_de_Vida : MonoBehaviour
{
    [SerializeField] private float tiempo_de_vida;
    void Start()
    {
        Destroy(gameObject, tiempo_de_vida);
    }
}
