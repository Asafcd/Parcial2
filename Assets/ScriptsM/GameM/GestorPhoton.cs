using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GestorPhoton : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        IvokePlayer();
    }


    public void IvokePlayer()
    {
        PhotonNetwork.Instantiate("Personaje", new Vector3(Random.Range(-7,7),1.14f,0), Quaternion.identity);
        PhotonNetwork.Instantiate("Main Camera", new Vector3(0,15,-22), Quaternion.identity);
    }

   
}
