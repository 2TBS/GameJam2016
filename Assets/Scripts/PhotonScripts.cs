using UnityEngine;
using System.Collections;

///Multiplayer-oriented functions for every player. 
//Author: Vikram P.
public class PhotonScripts : MonoBehaviour {

    public PhotonView temp;
    public Camera tempCam;
    public pl_controller plcont;
    public TextMesh username;
    public GameObject HUD;
    public PhotonView punView;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        

        if (temp.isMine)
        {
            username.text = PhotonNetwork.playerName;
            rb.isKinematic = false;
            Debug.Log("Mine");
            this.tag = "Player";
            HUD.SetActive(true);
            tempCam.enabled = true;
            plcont.enabled = true;
            //punView = PhotonView.Get(this);
            punView.RPC("setName", PhotonTargets.OthersBuffered, PhotonNetwork.player.ID, PhotonNetwork.playerName);
            
        }
        else
        {
            plcont.enabled = false;
            tempCam.enabled = false;
            HUD.SetActive(false); 
            this.tag = "Enemy";
            username.text = temp.owner.name;
            rb.isKinematic = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [PunRPC]
    public void setName(int id, string name)
    {
        Debug.Log("setName" + name);
        GameObject tempPlayers = PhotonView.Find(id).gameObject;
        Debug.Log(tempPlayers.ToString());
        tempPlayers.name = name;
    }
}
