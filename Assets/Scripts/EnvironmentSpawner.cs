using UnityEngine;
using System.Collections;

public class EnvironmentSpawner : MonoBehaviour {

	//Obstacle prefabs
	public Building buildingPrefab;
	public BoxBuilding boxPrefab;
	public RaisedBoxBuilding raisedBoxPrefab;

	private const int SPAWN_OFFSET_X = 100;

	// Use this for initialization
	void Start () {
		//TODO don't hard code these values....
		//i.e the y value could be the scale?

	}
	
	public void spawnObstacle(){
		boxPrefab.Spawn(new Vector3 (SPAWN_OFFSET_X, -3));
	}

	public void spawnBuilding(){
		int rand = Random.Range (0, 5);
		if (rand > 0) {
			buildingPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, -8));
		} else {
			raisedBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 2));
		}
	}
}
