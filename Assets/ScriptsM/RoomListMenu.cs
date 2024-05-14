using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    public Transform goContent;
    public RoomList roomList;
    private List<RoomList> listing = new List<RoomList>();
    public GameObject panelLobby;

    public override void OnJoinedRoom()
    {
        panelLobby.SetActive(true);
        goContent.DestroyChilodren();
        listing.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomInfos)
    {
        foreach (RoomInfo info in roomInfos)
        {
            if(info.RemovedFromList)
            {
                int index = listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(listing[index].gameObject);
                    listing.RemoveAt(index);
                }
            }
            else{
                int index = listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                  if(index == -1)
                {
                    RoomList list = Instantiate(roomList, goContent);
                    if(list != null)
                    {
                        list.SetRoomInfo(info);
                        listing.Add(list);
                    }
                }
            }
        }
    }



}
