using UnityEngine;
using System.Collections;

///Manages attached player's health and respawn when health is 0.!--
//Author: Vikram P.
public class pl_Health : MonoBehaviour {

    public int Health = 0;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [PunRPC]
    public void setHealth(int tempH)
    {
        Health = tempH;
    }

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if(Coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Touching enemy");
            //PhotonView.RPC("setHealth", PhotonTargets.OthersBuffered, );
        }
    }


}
