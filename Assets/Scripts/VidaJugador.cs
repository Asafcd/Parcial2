using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class VidaJugador : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual;
    public Slider vidaSlider;
    private bool isDead;
    private bool dañado;

    private bool medicamento;


    public GameObject gameOver;

    private PlayerController player;
    private Shoot shoot;



    public void Awake()
    {
        vidaActual = vidaInicial;
        vidaSlider.maxValue = vidaInicial;
        vidaSlider.value = vidaInicial; 

        player = GetComponent<PlayerController>();
        shoot=GetComponent<Shoot>();

    }

    public void dañoRecibido(int daño)
    {
        dañado = true;
        vidaActual -= daño;
        vidaSlider.value = vidaActual;

        if(vidaActual <= 0 && !isDead)
        {
            Death();
        }
    }

   public void Medicina(int cantidad)
    {
      if (!medicamento) 
        {
            vidaActual += cantidad; 
            if (vidaActual > vidaInicial) 
            {
                vidaActual = vidaInicial;
            }
            vidaSlider.value = vidaActual; 
            medicamento = true; 
            StartCoroutine(ResetMedicamento());
        }
    }

    IEnumerator ResetMedicamento()
    {
        yield return new WaitForSeconds(15); 
        medicamento = false; 
    }

 

    public void Death()
    {
        isDead = true;
        gameOver.SetActive(true);
        StartCoroutine(ReiniciarNivel());
        player.enabled = false;
        shoot.enabled = false;
    }

    IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");

    }

   
    
}
