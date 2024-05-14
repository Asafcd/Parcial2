using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ControllerView : MonoBehaviour
{
    public MonoBehaviour[] ignorar;
    private PhotonView photonView;

    private void Awake() {
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!photonView.IsMine)
        {
            foreach (var codigo in ignorar)
            {
                codigo.enabled = false;
                
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
