using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interfaces : MonoBehaviour
{
    [Header("Interfaces")]
    [SerializeField] private GameObject InterfazPausa;
    [SerializeField] private GameObject InterfazJuego;
    [SerializeField] private GameObject InterfazCinematica;
    [SerializeField] private GameObject Victoria;
    [SerializeField] private GameObject Derrota;

    [Header("Configuración Botones")]
    [SerializeField] private GameObject BotonReiniciar;
    [SerializeField] private GameObject BotonSalir;
    [SerializeField] private RectTransform PosicionVictoriaReiniciar;
    [SerializeField] private RectTransform PosicionVictoriaSalir;
    [SerializeField] private RectTransform PosicionDerrotaReiniciar;
    [SerializeField] private RectTransform PosicionDerrotaSalir;

    [Header("Configuraciones Cinematicas")]
    [SerializeField] private GameObject BotonSaltar;
    [SerializeField] private Image Persona00;
    [SerializeField] private Image Persona01;
    [SerializeField] private Text Mensaje;
    [SerializeField] private Text VictoriaTexto;
    [SerializeField] private Text DerrotaTexto;
    [SerializeField] private Sprite[] Persona00Cinematicas;
    [SerializeField] private Sprite[] Persona01Cinematicas;
    [SerializeField] private string[] MensajeCinematicas;
    [SerializeField] private int[] PuntosDeControlCinematicas;

    private int TutorialLimite = 6;
    private int IndicePuntosDeControl;
    private int SiguientePuntoDeControl;
    private int IndiceCinematica;
    private int PuntosFinales;
    void Start()
    {
        Time.timeScale = 0.0f;
        PuntosFinales = 0;
        SiguientePuntoDeControl = PuntosDeControlCinematicas[0];
        IndiceCinematica = 0;
        IndicePuntosDeControl = 0;
        for (int i = 0; i < MensajeCinematicas.Length; i++)
        {
            MensajeCinematicas[i] = MensajeCinematicas[i].Replace('/', '\n');
        }
        BotonReiniciar.SetActive(false);
        BotonSalir.SetActive(false);
        InterfazCinematica.SetActive(true);
        InterfazPausa.SetActive(false);
        InterfazJuego.SetActive(false);
        Victoria.SetActive(false);
        Derrota.SetActive(false);
        
        ImprimirCinematica();
    }
    private void ImprimirCinematica()
    {
        if(IndiceCinematica < Persona00Cinematicas.Length)
        {
            if (Persona00Cinematicas[IndiceCinematica].IsUnityNull())
            {
                Persona00.enabled = false;
            }
            else
            {
                Persona00.enabled = true;
                Persona00.sprite = Persona00Cinematicas[IndiceCinematica];
            }
            if (Persona01Cinematicas[IndiceCinematica].IsUnityNull())
            {
                Persona01.enabled = false;
            }
            else
            {
                Persona01.enabled = true;
                Persona01.sprite = Persona01Cinematicas[IndiceCinematica];
            }
            Mensaje.text = MensajeCinematicas[IndiceCinematica];
        }
    }
    public void ActivarSiguienteCinematica()
    {
        Time.timeScale = 0.0f;

        InterfazCinematica.SetActive(true);
        InterfazJuego.SetActive(false);

        ImprimirCinematica();
    }
    public void ResultadosFinales(bool SinDañoEsteNivel, bool BossDerrotado, int EnemigosRestantes, int BalasRestantes, float Tiempo)
    {
        if (SinDañoEsteNivel)
        {
            PuntosFinales += 500;
        }
        if (BossDerrotado)
        {
            PuntosFinales += 500;
        }
        if( EnemigosRestantes == 0)
        {
            PuntosFinales += 500;
        }
        PuntosFinales += (BalasRestantes * 20);
        PuntosFinales += (int)(6000 - (Mathf.Floor(Tiempo / 60) + Mathf.Floor(Tiempo % 60)));
    }
    public void VictoriaPantalla()
    {
        Time.timeScale = 0.0f;
        Victoria.SetActive(true);
        InterfazCinematica.SetActive(false);
        VictoriaTexto.text = "VICTORIA\nPUNTAJE: " + PuntosFinales.ToString();
        BotonReiniciar.GetComponent<RectTransform>().position = PosicionVictoriaReiniciar.position;
        BotonSalir.GetComponent<RectTransform>().position = PosicionVictoriaSalir.position;
        BotonReiniciar.SetActive(true);
        BotonSalir.SetActive(true);
    }
    public void DerrotaPantalla()
    {
        Time.timeScale = 0.0f;
        InterfazJuego.SetActive(false);
        Derrota.SetActive(true);
        DerrotaTexto.text = "DERROTA\nPUNTAJE: " + PuntosFinales.ToString();
        BotonReiniciar.GetComponent<RectTransform>().position = PosicionDerrotaReiniciar.position;
        BotonSalir.GetComponent<RectTransform>().position = PosicionDerrotaSalir.position;
        BotonReiniciar.SetActive(true);
        BotonSalir.SetActive(true);
    }
    public void AvanzarCinematica() {
        IndiceCinematica++;
        if(IndiceCinematica >= Persona00Cinematicas.Length)
        {
            VictoriaPantalla();
        }
        else
        {
            if (TutorialLimite == IndiceCinematica)
            {
                BotonSaltar.SetActive(false);
            }
            if (IndiceCinematica == SiguientePuntoDeControl)
            {
                IndicePuntosDeControl++;
                if (IndicePuntosDeControl >= PuntosDeControlCinematicas.Length)
                {
                    VictoriaPantalla();
                }
                else
                {
                    SiguientePuntoDeControl = PuntosDeControlCinematicas[IndicePuntosDeControl];
                    Time.timeScale = 1.0f;
                    InterfazCinematica.SetActive(false);
                    InterfazJuego.SetActive(true);
                }
            }
            else
            {
                ImprimirCinematica();
            }
        }
        
    }
    public void AdelantarTutorial()
    {
        IndiceCinematica = TutorialLimite - 1;
        AvanzarCinematica();
    }
    public void Pausar()
    {
        Time.timeScale = 0.0f;
        InterfazPausa.SetActive(true);
        InterfazJuego.SetActive(false);
        BotonReiniciar.SetActive(true);
        BotonSalir.SetActive(true);
    }
    public void Despausar()
    {
        Time.timeScale = 1.0f;
        InterfazPausa.SetActive(false);
        InterfazJuego.SetActive(true);
        BotonReiniciar.SetActive(false);
        BotonSalir.SetActive(false);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
