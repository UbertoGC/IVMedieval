using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControladorImagenes : MonoBehaviour
{
    [Header("Elementos")]
    [SerializeField] private Image Botón;
    [SerializeField] private Image Imagen;
    [SerializeField] private Text Mensaje;
    [SerializeField] private Sprite[] Imagenes;
    [SerializeField] private string[] Texto;
    [SerializeField] private float OscuridadPorUpdate;
    private int indice = 0;
    private bool CambioEscenario = false;
    private bool CargandoEscenario = false;
    // Start is called before the first frame update
    private void Start()
    {
        Imagen.sprite = Imagenes[indice];
        Mensaje.text = Texto[indice];
    }
    private void Update()
    {
        if (CambioEscenario)
        {
            if(Imagen.color.r == 0f && CargandoEscenario == false)
            {
                CargandoEscenario = true;
                indice++;
                Imagen.sprite = Imagenes[indice];
                Mensaje.text = Texto[indice];
            }
            else if(CargandoEscenario)
            {
                Color Cambio = new Color(1, 1, 1);
                if (Imagen.color.r < 1f)
                {
                    Cambio.r = OscuridadPorUpdate;
                    Cambio.g = OscuridadPorUpdate;
                    Cambio.b = OscuridadPorUpdate;
                    Botón.color += Cambio;
                    Imagen.color += Cambio;
                }
                else
                {
                    Botón.color = Cambio;
                    Imagen.color = Cambio;
                }
                if (Botón.color.r == 1f)
                {
                    CargandoEscenario = false;
                    CambioEscenario = false;
                }
            }
            else
            {
                if (Imagen.color.r >= OscuridadPorUpdate)
                {
                    
                    Color Cambio = new Color();
                    Cambio.r = OscuridadPorUpdate;
                    Cambio.g = OscuridadPorUpdate;
                    Cambio.b = OscuridadPorUpdate; 
                    Botón.color -= Cambio;
                    Imagen.color -= Cambio;
                    Debug.Log(Imagen.color.r);
                    Debug.Log(Cambio.r);
                }
                else
                {
                    Botón.color = Color.black;
                    Imagen.color = Color.black;
                }
                
            }
        }
    }
    // Update is called once per frame
    public void SiguienteImagen()
    {
        if(indice < Imagenes.Length - 1)
        {
            CambioEscenario = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
