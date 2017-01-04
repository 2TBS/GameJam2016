using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Manages the multiplayer functions for the Main Menu.
//Author: Vikram P, Ben C.
public class PhotonLobby : MonoBehaviour {

	public Text username;
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (PhotonNetwork.connectionStateDetailed.ToString ());
	}
		
	public void OnPlay(){
		PhotonNetwork.playerName = username.text;
		Debug.Log("Connecting as " + PhotonNetwork.playerName);
		PhotonNetwork.CreateRoom("TestMaze");

	}
	void OnPhotonCreateRoomFailed(){
		PhotonNetwork.JoinRoom ("TestMaze");
	}

	void OnJoinedRoom(){
		PhotonNetwork.isMessageQueueRunning = false;
		PhotonNetwork.LoadLevel ("BlockerMaze");

	}
}
