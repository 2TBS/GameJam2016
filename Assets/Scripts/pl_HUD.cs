using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// Controls the Heads-Up Display for attached player. 
// Author: Ben C.
public class pl_HUD : MonoBehaviour {

	public Text speedText;
	public Text healthText;
	// Use this for initialization
	void Start () {
		speedText = GameObject.Find("Speed Text").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		speedText.text = GetComponentInParent<pl_controller> ().GetCurrentSpeed();
	}
}
