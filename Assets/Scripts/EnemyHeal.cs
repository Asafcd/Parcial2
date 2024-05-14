using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyHeal : MonoBehaviourPun
{
    public int vidaInicial = 100;
    public int vidaActual;
    public float velocidadDesvanecer = 2.5f;
    private bool muerto;
    private bool desvanecido;

    public int puntosEnemigos;

    public Animator anim;


    // Start is called before the first frame update

    private void Awake() {
        vidaActual = vidaInicial;
    }

    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(desvanecido)
        {
            transform.Translate(Vector3.up  * velocidadDesvanecer * Time.deltaTime);
        }
        
    }

    public void damageRecibido(int damage, Vector3 hitpoint) 
    {
        if(muerto) return;
        vidaActual -=damage;

        if(vidaActual <= 0)
        {
            Muerto();
            photonView.RPC("RPC_Muerto", RpcTarget.AllBuffered);
        }
    }

    private void Muerto(){
        muerto = true;
        desvanecido = true;
        PuntosManager.puntos += puntosEnemigos;
        anim.SetTrigger("EnemyDie");
        Destroy(gameObject, 2f);

    }

    [PunRPC]
    private void RPC_Muerto()
    {
        muerto=true;
        desvanecido = true;
        PuntosManager.puntos += puntosEnemigos;
        Destroy(gameObject,2f);
    }

}
