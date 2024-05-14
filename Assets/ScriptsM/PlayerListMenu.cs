using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListMenu : MonoBehaviourPunCallbacks
{
 public Transform goContent;
    public PlayerList playerList;
    private List<PlayerList> listing = new List<PlayerList>();

    public override void OnEnable(){
        base.OnEnable();
        GetCurrentRoomPlayer();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i =0; i < listing.Count; i++)
        {
            Destroy(listing[i].gameObject);
            
        }
        listing.Clear();
    }

    private void GetCurrentRoomPlayer()
    {
        if(!PhotonNetwork.IsConnected)return;
        if(PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)return;
        foreach(KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            addPlayerListing(playerInfo.Value);
        }
    }

    private void addPlayerListing(Player player)
    {
   
                int index = listing.FindIndex(x => x.Player == player);
                if(index != -1)
                {
                    listing[index].setPlayerInfo(player);
                }
                else{
                     PlayerList list = Instantiate(playerList, goContent);
                    if(list != null)
                    {
                        list.setPlayerInfo(player);
                        listing.Add(list);
                    }
                }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        addPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listing.FindIndex(x => x.Player == otherPlayer);
        if(index != -1)
        {
            Destroy(listing[index].gameObject);
            listing.RemoveAt(index);
        }
    }

    public void onclick_StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("SampleScene");
        }
    }

}
