using UnityEngine;
using System.Collections;

public class EnemyDebbuf : MonoBehaviour {
    private int fastTime;
    private EnemigoManager _enemigoManager;
    public int timeF ;


    private bool consumio = true;


    private void Awake() {
       _enemigoManager = FindObjectOfType<EnemigoManager>();


    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
        FastTime();
        Destroy(gameObject);         
        consumio = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
         {

        }
    }


     private void FastTime()
    {
        fastTime = _enemigoManager.currentspawnTime - timeF;
        _enemigoManager.UpdateTime(fastTime);
    }




}