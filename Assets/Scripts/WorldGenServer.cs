using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///Server-side functions for maze generation.
//Recieves and manages client-side spawn queues from all players.
//Author: Ben C. 
public class WorldGenServer : MonoBehaviour {

public int tileSize = 11;
public List<Vector2> coordList;
public List<Vector2> spawnedCoordList;
public WorldGenClient[] playerList;
public List<PhotonView> tileList;
	// Use this for initialization
	void Start () {
		spawnedCoordList.Add(new Vector2(0,0));
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Tile")) {
			tileList.Add(obj.GetPhotonView());
		}
		playerList = (GameObject.FindObjectsOfType<WorldGenClient> ());
		ConsolidatePlayerCoords();
		GenerateMaze();
		RemoveTiles();
	}

	void ConsolidatePlayerCoords() {
		foreach(WorldGenClient player in playerList) {
			foreach(Vector2 coord in player.spawnQueue) {
				if(!coordList.Contains(coord)) {
					coordList.Add(coord);
					Debug.Log("Player " + player.name + " added " + coord.ToString() + " to spawnQueue");
				}
			}
		}
	}

	void GenerateMaze() {
		foreach(Vector2 coord in coordList) {
			if(!CheckForTile(coord)) {
			PhotonNetwork.Instantiate("Tile " + Random.Range(2,5), coord*tileSize, Quaternion.identity, 0);
			coordList.Remove(coord);
			Debug.Log("Spawned tile at " + coord.ToString());
			spawnedCoordList.Add(coord);
			} 
		}
	}

	void RemoveTiles() {
		if(playerList.Length*9 < spawnedCoordList.Count) {
				int randomIndex = Random.Range(1,tileList.Count);
				Vector2 randomCoords = new Vector2(Mathf.Round(tileList[randomIndex].transform.position.x / tileSize), Mathf.Round(tileList[randomIndex].transform.position.y / tileSize));
				if(spawnedCoordList.Contains(randomCoords)) {
					foreach(WorldGenClient player in playerList) {
						if(player.GetCoordsNearPlayer().Contains(randomCoords)) {
							Debug.LogWarning("Tile to be removed is occupied");
						} else {
							PhotonNetwork.Destroy(tileList[randomIndex]);
							spawnedCoordList.Remove(randomCoords);
							Debug.Log("Tile removed at " + randomCoords.ToString());
						}
					
					}
					
				}
			
		} 
	}

	public bool CheckForTile(Vector2 coordinates) {
		return (spawnedCoordList.Contains(coordinates));
	}
}
