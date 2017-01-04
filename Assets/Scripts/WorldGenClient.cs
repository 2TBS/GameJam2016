using UnityEngine;
using System.Collections.Generic;

///Functions that every player carries out for maze generation.
//Generates a spawn queue based on surrounding coordinates.
//Author: Ben C.
public class WorldGenClient : MonoBehaviour {

private int tileSize = 11; //size of a single maze tile, in units
public Transform player;
public List<Vector2> spawnQueue;
public int[] prefabID;
public Vector2 currentCoords;
public WorldGenServer server;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Transform> ();
		server = GameObject.FindObjectOfType<WorldGenServer>();
	}
	
	// Update is called once per frame
	void Update () {
		currentCoords = new Vector2(Mathf.Round(player.position.x/tileSize), Mathf.Round(player.position.y/tileSize));
		ManageSpawnQueue();
	}

	public List<Vector2> GetCoordsNearPlayer() {
		List<Vector2> returnValue = new List<Vector2> {currentCoords, 
								new Vector2(currentCoords.x,currentCoords.y+1),
								new Vector2(currentCoords.x+1,currentCoords.y+1),
								new Vector2(currentCoords.x+1,currentCoords.y),
								new Vector2(currentCoords.x+1,currentCoords.y-1),
								new Vector2(currentCoords.x,currentCoords.y-1),
								new Vector2(currentCoords.x-1,currentCoords.y-1),
								new Vector2(currentCoords.x-1,currentCoords.y),
								new Vector2(currentCoords.x-1,currentCoords.y+1), };
		return returnValue;
	}

	public void ManageSpawnQueue() {
		foreach(Vector2 coord in GetCoordsNearPlayer()) {
			if(!spawnQueue.Contains(coord)) spawnQueue.Add(coord);
		}

		foreach(Vector2 coord in spawnQueue) {
			if(server.CheckForTile(coord) || TilePresent(coord)) {
				spawnQueue.Remove(coord);
			}
		}
	}
	
	//checks to see if tile is already present
	bool TilePresent (Vector2 coordinates) {
		foreach (Vector2 coord in spawnQueue) {
			if(coord == coordinates) return true; //There's a reason for this seemingly bad code convention. Don't question it
		} return false;
	}
	
	
}
