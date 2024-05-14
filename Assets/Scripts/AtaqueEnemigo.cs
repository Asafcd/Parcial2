using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public float tiempoAtaque;
    public int dañoEnemigo;
    private GameObject player;
    private VidaJugador _vidaJugador;
    private EnemyHeal _vidaEnemigo;
    private bool playerRango;
    private float timer;
    public Animator anim;


    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _vidaJugador = player.GetComponent<VidaJugador>();
        _vidaEnemigo = GetComponent<EnemyHeal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerRango = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerRango = false;
                        anim.SetBool("EnemyAttack", false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoAtaque && playerRango && _vidaEnemigo.vidaActual > 0)
        {
            anim.SetBool("EnemyAttack", true);
            Ataque();
        }
    }

    private void Ataque()
    {
        timer = 0;
        if (_vidaJugador.vidaActual > 0)
        {
            _vidaJugador.dañoRecibido(dañoEnemigo);
            
        }
    }


}
