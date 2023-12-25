using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadisticas_Enemigos : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;

    [Header("Estadísticas")]
    [SerializeField] private float Vida = 10;
    [SerializeField] private float Daño_melee = 5;
    [SerializeField] private Transform ControlDisparo;
    [SerializeField] private AudioSource SonidoDisparo;
    [SerializeField] private GameObject Bala;
    [SerializeField] private GameObject Recompensa;
    [SerializeField] private GameObject Animacion_muerte;
    [SerializeField] private Estadisticas_jugador InformacionJugador;

    [Header("Movimiento de Enemigo")]
    [SerializeField] private int Tipo;
    [SerializeField] private float VelocidadMovimiento;
    [SerializeField] private Transform ControladorSuelo;
    [SerializeField] private LayerMask TipoSuelo;
    public bool atacando = false;
    private float VelocidadAtaque = 2.5f;
    private float TiempoVigilia = 3.0f;
    public float TiempoEspera = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (atacando)
        {
            rb2D.velocity = Vector2.zero;
            if (TiempoEspera <= 0)
            {
                Disparar();
                TiempoEspera = VelocidadAtaque;
            }
            else
            {
                TiempoEspera -= Time.deltaTime;
            }
        }
        else if (Tipo == 0)
        {
            if (TiempoVigilia <= 0)
            {
                Girar();
                TiempoVigilia = 3.0f;
            }
            else
            {
                TiempoVigilia -= Time.deltaTime;
            }
        }
        else if (Tipo == 1)
        {
            animator.SetBool("Traslado", true);
            rb2D.velocity = new Vector2(VelocidadMovimiento * transform.right.x, rb2D.velocity.y);
            RaycastHit2D InformacionSuelo = Physics2D.Raycast(ControladorSuelo.position, Vector2.down, 1.0f, TipoSuelo);
            RaycastHit2D InformacionTecho = Physics2D.Raycast(ControladorSuelo.position, Vector2.up, 1.95f, TipoSuelo);
            RaycastHit2D InformacionParedAlta = Physics2D.Raycast(ControladorSuelo.position, Vector2.up, 1.4f, TipoSuelo);
            RaycastHit2D InformacionParedMedia = Physics2D.Raycast(transform.position, transform.right, 0.75f, TipoSuelo);
            RaycastHit2D InformacionParedBaja = Physics2D.Raycast(ControladorSuelo.position, Vector2.down, 0.4f, TipoSuelo);
            if (InformacionSuelo == false || InformacionParedAlta == true || InformacionParedBaja == true || InformacionParedMedia == true){
                Girar();
            }
        }
    }
    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ControladorSuelo.position, ControladorSuelo.position + Vector3.up * 1.95f);
        Gizmos.DrawLine(ControladorSuelo.position, ControladorSuelo.position + Vector3.down * 1.0f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ControladorSuelo.position, ControladorSuelo.position + Vector3.down * 0.4f);
        Gizmos.DrawLine(ControladorSuelo.position, ControladorSuelo.position + Vector3.up * 1.4f);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 0.75f);
    }
    private void Disparar()
    {
        SonidoDisparo.Play();
        Instantiate(Bala, ControlDisparo.position, ControlDisparo.rotation);
    }
    public void Recibir_Daño(float daño)
    {
        Vida -= daño;
        if (Vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        InformacionJugador.EnemigoDerrotado();
        Instantiate(Animacion_muerte, transform.position, transform.rotation);
        Instantiate(Recompensa,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
