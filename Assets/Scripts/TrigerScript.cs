using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            
            //Destroy(other.gameObject, 5f);

            
        }
    }

    private void OnTriggerExit(Collider other) {
         if(other.CompareTag("Player"))
        {
           other.transform.position = new Vector3(0,0,0);
           
        }
    }

    private void OnTriggerStay(Collider other) {
        {
            //other.transform.localScale = Vector3.Lerp(other.transform.localScale, new Vector3(0.1f,0.1f,0.1f), 0.5f * Time.deltaTime );
        }
    }


}
