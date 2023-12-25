using UnityEngine;
using UnityEngine.UI;

public class Estadisticas_jugador : MonoBehaviour
{
    private Animator animator;
    [Header("Entorno")]
    [SerializeField] private int EnemigosEnEsteNivel;

    [Header("Sonidos Jugador")]
    [SerializeField] private AudioSource GritoAlRecibirDa�o;
    [SerializeField] private AudioSource GritoAlMorir;
    [SerializeField] private AudioSource Disparo;
    [SerializeField] private Movimiento_Jugador ArchivoDeMovimiento;

    [Header("Estadisticas Jugador")]
    [SerializeField] private float VidaInicial;
    [SerializeField] private int CantidadDeBalasInicial;
    [SerializeField] private Text ContadorBalas;
    [SerializeField] private Text ContadorVida;
    [SerializeField] private Text ContadorEnemigos;
    [SerializeField] private Image[] EstrellasImagenes;
    [SerializeField] private Sprite EstrellaPositiva;
    [SerializeField] private Sprite EstrellaNegativa;
    [SerializeField] private Transform control_disparo;
    [SerializeField] private GameObject bala;
    
    [Header("Controlador de Interfaces")]
    [SerializeField] private Interfaces ControladorInterfaces;

    private int CantidadDeBalas;
    private int EnemigosRestantes;
    private float Vida;
    private bool SinDa�oEsteNivel;
    private bool BossDerrotado;
    private bool ResultadosEnviados;
    private float TiempoDeFinalizacion;
    private float TiempoDeJuego;
    private bool YaDisparo;
    void Start()
    {
        animator = GetComponent<Animator>();
        YaDisparo = false;
        ResultadosEnviados = false;
        TiempoDeJuego = 0;
        TiempoDeFinalizacion = 1.5f;
        EnemigosRestantes = EnemigosEnEsteNivel;
        SinDa�oEsteNivel = true;
        BossDerrotado = false;
        Vida = VidaInicial;
        CantidadDeBalas = CantidadDeBalasInicial;
        ContadorVida.text = Vida.ToString();
        ContadorBalas.text = CantidadDeBalas.ToString();
        ContadorEnemigos.text = EnemigosRestantes.ToString();
        EstrellasImagenes[0].sprite = EstrellaPositiva;
    }
    void Update()
    {
        if(ArchivoDeMovimiento.EntradasAcciones.Interaccion.Disparo.ReadValue<float>() == 0)
        {
            YaDisparo = false;
        }
        else if (ArchivoDeMovimiento.EntradasAcciones.Interaccion.Disparo.ReadValue<float>() != 0 && Vida > 0 && !ResultadosEnviados && !YaDisparo)
        {
            Disparar();
            YaDisparo = true;
        }
        if(!ResultadosEnviados)
        {
            if (BossDerrotado)
            {
                if (TiempoDeFinalizacion > 0)
                {
                    TiempoDeFinalizacion -= Time.deltaTime;
                }
                else
                {
                    ControladorInterfaces.ResultadosFinales(SinDa�oEsteNivel, BossDerrotado, EnemigosRestantes, CantidadDeBalas, TiempoDeJuego);
                    ControladorInterfaces.ActivarSiguienteCinematica();
                    ResultadosEnviados = true;
                }

            }
            if (Vida == 0)
            {
                if (TiempoDeFinalizacion > 0)
                {
                    TiempoDeFinalizacion -= Time.deltaTime;
                }
                else
                {
                    ControladorInterfaces.ResultadosFinales(SinDa�oEsteNivel, BossDerrotado, EnemigosRestantes, CantidadDeBalas, TiempoDeJuego);
                    ControladorInterfaces.DerrotaPantalla();
                    ResultadosEnviados = true;
                }
            }
            else
            {
                TiempoDeJuego += Time.deltaTime * Time.timeScale;
            }
        }
    }
    
    public void Disparar()
    {
        if(CantidadDeBalas > 0) {
            Disparo.Play();
            Instantiate(bala, control_disparo.position, control_disparo.rotation);
            CantidadDeBalas--;
            ContadorBalas.text = CantidadDeBalas.ToString();
        }
    }
    public void AumentarBalas(int AumentoDeBalas)
    {
        CantidadDeBalas += AumentoDeBalas;
        ContadorBalas.text = CantidadDeBalas.ToString();
    }
    public void EnemigoDerrotado()
    {
        EnemigosRestantes--;
        ContadorEnemigos.text = EnemigosRestantes.ToString();
        if (EnemigosRestantes == 0)
        {
            EstrellasImagenes[1].sprite = EstrellaPositiva;
        }
    }
    public void JefeDerrotado()
    {
        BossDerrotado = true;
        EstrellasImagenes[2].sprite = EstrellaPositiva;
    }
    public void Recibir_Da�o(float da�o)
    {
        Vida -= da�o;
        if (SinDa�oEsteNivel)
        {
            EstrellasImagenes[0].sprite = EstrellaNegativa;
            SinDa�oEsteNivel = !SinDa�oEsteNivel;
        }
        if (Vida <= 0)
        {
            GritoAlMorir.Play();
            Vida = 0f;
            animator.SetBool("Estado", false);
        }
        else
        {
            GritoAlRecibirDa�o.Play();
        }
        
        ContadorVida.text = Vida.ToString();
    }
}
