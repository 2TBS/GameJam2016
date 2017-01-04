using UnityEngine;
using System.Collections;

///Randomly assigns a color to the maze block this is attached to.
//Author: Ben C.
public class TileColor : MonoBehaviour {
	public SpriteRenderer thisTile;
	public Color currentColor;
	// Use this for initialization
	void Start () {
		thisTile = GetComponent<SpriteRenderer> ();
		thisTile.color = new Color (Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1);
	}
	
	void Update() {
		
	}
	// Update is called once per frame
	
	}
