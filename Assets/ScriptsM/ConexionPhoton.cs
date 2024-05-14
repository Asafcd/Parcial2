using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ConexionPhoton : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI textConexion;

    // Start is called before the first frame update
    void Start()
    {
        StartConnection();
        
    }

    public void StartConnection()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "Test" + Random.Range(0,999);
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnConnectedToMaster()
    {
        textConexion.text = "Conexion exitosa";
        textConexion.color = Color.green;
        if(!PhotonNetwork.InLobby)
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        textConexion.text = "Conexion Fallida";
        textConexion.color = Color.red;
        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joided lobby");
    }

    // Update is called once per frame

}
