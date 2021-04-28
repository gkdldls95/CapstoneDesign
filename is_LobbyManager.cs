using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class is_LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "2";   // 1은 솔로 2는 멀티 예정??
    public Text connectionInfoText;
    public Button joinButton;


    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "온라인 : 마스터 서버와 연결됨";
    } // 서버 연결시 룸 접속 버튼 활성화

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음";
        PhotonNetwork.ConnectUsingSettings();
        connectionInfoText.text += "  (연결 재시도중)";
    }

    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = " 룸에 접속 시도";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인 : 연결되지 않음";
            PhotonNetwork.ConnectUsingSettings();
            connectionInfoText.text += "  (연결 재시도중)";
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = " 빈방이 없으므로, 새로운 방 생성 ";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });

    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        PhotonNetwork.LoadLevel("MainScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        joinButton.interactable = false;
        connectionInfoText.text = "마스터 서버에 접속 중...";
    }

}