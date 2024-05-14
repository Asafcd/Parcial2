using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class MoveEnemy : MonoBehaviourPun
{
    //private EnemyHeal _enemyHeal;
    private  NavMeshAgent nav;
    public GameObject targetPlayer;
    public GameObject[] players;




   // private VidaJugador _vidajugador;

    // Start is called before the first frame update
   private  void Start()
    {
       // _enemyHeal = GetComponent<EnemyHeal>();
        nav = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpdateTarget",0f,1f);

       // _vidajugador = player.GetComponent<VidaJugador>();
    }

    void UpdateTarget()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        float distanceShort = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach(GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < distanceShort)
            {
                distanceShort = distanceToPlayer;
                nearestPlayer = player;
            }
        }
        targetPlayer = nearestPlayer;

    }

    // Update is called once per frame
     void Update()
    {
        if(targetPlayer != null)
        {
            nav.SetDestination(targetPlayer.transform.position);
            
        }

    }
}
