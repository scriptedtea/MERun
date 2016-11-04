using UnityEngine;
using System.Collections;

public class EnvironmentSpawner : MonoBehaviour {

	//Obstacle prefabs
	public Building buildingPrefab;
	public Box boxPrefab;
	public RaisedBox raisedBoxPrefab;
	public 

	// Use this for initialization
	void Start () {

	}
	
	public void spawnObstacle(){
		spawnBuilding ();
		//TODO don't hard code these values....
		//i.e the y value could be the scale?
		raisedBoxPrefab.Spawn (new Vector3 (20f, -0.6f));
	}

	public void spawnBuilding(){
		//int buildingSize = 8 + (4 * Random.Range (0, 3));

		//buildingPrefab.gameObject.transform

		int offset = 10;
		buildingPrefab.Spawn (new Vector3 (100, -8));
	}
}
