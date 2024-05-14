using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class RoomList : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public RoomInfo RoomInfo {get; private set;}
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        textInfo.text = roomInfo.MaxPlayers + " - " + roomInfo.Name;
    }

    public void onclick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        
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
