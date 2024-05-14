using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveScene : MonoBehaviour
{
    public GameObject PanelLobby;

    public void onClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        PanelLobby.SetActive(false);
    }


   
}
