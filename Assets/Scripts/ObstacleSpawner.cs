using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public Building buildingPrefab;

	// Use this for initialization
	void Start () {

	}
	
	public void spawnObstacle(){
		buildingPrefab.Spawn (new Vector3 (10, -8));
	}
}
