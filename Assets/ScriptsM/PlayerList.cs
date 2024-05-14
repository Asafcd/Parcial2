using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;


public class PlayerList : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public Player Player {get; private set;}

    public void setPlayerInfo(Player playerInfo)
    {
        Player = playerInfo;
        textInfo.text = Player.NickName;
    }


   
}
