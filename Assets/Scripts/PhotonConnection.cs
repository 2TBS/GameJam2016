using UnityEngine;
using System.Collections;

///Multiplayer functions for the server side.
//Author: Vikram P.
public class PhotonConnection : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        string ply = "Player Character";
		PhotonNetwork.isMessageQueueRunning = true;
        GameObject instPlayer = PhotonNetwork.Instantiate(ply, new Vector3(0, 0, 0), Quaternion.identity,0);
		instPlayer.name = PhotonNetwork.playerName;
		Debug.Log("Player " + PhotonNetwork.playerName + " joined");
        
    }
	
	// Update is called once per frame
	void Update () {
	}
}
