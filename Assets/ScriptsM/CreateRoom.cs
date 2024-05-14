using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class CreateRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField nameroom;
    public GameObject panelLobby;

    public void OnclickCreateRoom()
    {
        if(!PhotonNetwork.IsConnected) return;

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;

        PhotonNetwork.JoinOrCreateRoom(nameroom.text,options,TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room creado");
        panelLobby.SetActive(true);        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
       Debug.Log("Creacion fallida");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
