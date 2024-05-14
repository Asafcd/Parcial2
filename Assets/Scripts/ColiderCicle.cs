using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColiderCicle : MonoBehaviour
{

     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
        }
        
    }

    private void OnCollisionExit(Collision other) {
          if(other.gameObject.CompareTag("Player"))
        {
            //Instantiate(other.gameObject, new Vector3(0,10,0),Quaternion.identity);
        }
    }

    private void OnCollisionStay(Collision other){
         if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log(message:"Suavemente besame que quiero sentir tus labios");
        }

    }

}
