using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviourPun
{
    [SerializeField] public float suavisado = 5f;
    [SerializeField] public GameObject target;
    public Vector3 offset;


    // Start is called before the first frame update
    private void Start() {
        if(!photonView.IsMine && PhotonNetwork.IsConnected) 
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) return;
        target = GameObject.FindGameObjectWithTag("Player");

        if (target != null) 
        {
            Transform localPlayer = target.transform;
            Vector3 desirePosition = localPlayer.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, suavisado);
            transform.position = smoothPosition;

            transform.LookAt(localPlayer);
        }


    }

}
