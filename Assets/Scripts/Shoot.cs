using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;


public class Shoot : MonoBehaviourPun
{
    public int damege = 20;
    public float TiempoEntreBala = 0.15f;
    public float rango = 100f;
    public float timePause = 7f;    

    private int baseDamage;

    private bool Shootactive = false;

    private float tiempo;
    private Ray disparoRay;
    private RaycastHit disparoHit;
    private int disparableMask;
    private LineRenderer disparoLine;
    private PlayerController _player;

    private void Awake()
    {
        disparableMask = LayerMask.GetMask("disparable");
        disparoLine = GetComponent<LineRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        baseDamage = damege;
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        if(Input.GetButton("Fire1") && tiempo >= TiempoEntreBala )
        {
            StartCoroutine(Disparo());
        }
        if(tiempo >= TiempoEntreBala * 0.2f)
        {
            disparoLine.enabled = false;
            photonView.RPC("RFC_HideBullet",RpcTarget.Others);
        }   
    }

    IEnumerator Disparo() 
    {
        tiempo = 0;
        yield return new WaitForSeconds(0.2f);
        disparoLine.enabled = true;
        disparoLine.SetPosition(0, transform.position);
        disparoRay.origin = transform.position;
        disparoRay.direction = transform.forward;

        if(Physics.Raycast(disparoRay, out disparoHit, rango, disparableMask))
        {
            EnemyHeal enemyHeal = disparoHit.collider.GetComponent<EnemyHeal>();
            if (enemyHeal != null) {
                enemyHeal.damageRecibido(baseDamage, disparoHit.point);
            }
            disparoLine.SetPosition(1, disparoHit.point);
        }
        else{
            disparoLine.SetPosition(1, disparoRay.origin + disparoRay.direction * rango);
        }

        photonView.RPC("RPC_showBullet",RpcTarget.Others, disparoLine.GetPosition(0),disparoLine.GetPosition(1));
    }

    [PunRPC] 
    public void RPC_showBullet(Vector3 startPos, Vector3 endPos)
    {
        disparoLine.enabled = true;
        disparoLine.SetPosition(0,startPos);
        disparoLine.SetPosition(1,endPos);

    }

    [PunRPC]
    public void RFC_HideBullet()
    {
        disparoLine.enabled = false;
    }

    public void AumentoD(int aumentoDaño)
    {
        _player.ChangeColor(Color.blue);
        baseDamage = aumentoDaño;
        Shootactive = true;
        StartCoroutine(ResetDamage());
    }

     IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(timePause); 
        Shootactive = false; 
        baseDamage = damege;
        _player.ChangeColor(Color.red);
        Debug.Log("El daño se ha recuperado a: " + damege);

    }
}

