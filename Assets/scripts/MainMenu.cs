using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public InputField create_input;
    public InputField join_input;
    public void create_room()
    {
        RoomOptions room_options = new RoomOptions();
        room_options.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(create_input.text, room_options);
    }
    public void join_room()
    {
        PhotonNetwork.JoinRoom(join_input.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public void exit()
    {
        Application.Quit();
    }
}
