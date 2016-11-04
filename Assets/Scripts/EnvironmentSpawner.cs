using UnityEngine;
using System.Collections;

public class EnvironmentSpawner : MonoBehaviour {

	//Obstacle prefabs
	public Building buildingPrefab;
	public Box boxPrefab;
	//public BoxBuilding boxBuildingPrefab;
	public RaisedBoxBuilding raisedBoxPrefab;
	public SlideBox slideBoxPrefab;

	//TODO refactor back to int?
	private const float SPAWN_OFFSET_X = 100;

	// Use this for initialization
	void Start () {
		//TODO don't hard code these values....
		//i.e the y value could be the scale?

	}
	
	public void spawnObstacle(){

		int rand =1;//= Random.Range (0, 2);
		if (rand > 1) {
			int boxOffset = -1;
			boxPrefab.Spawn(new Vector3 (SPAWN_OFFSET_X + boxOffset, -1.5f));
			spawnBuilding ();
		} else {

			slideBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 3));
			spawnPlainBuilding ();
		}


	}

	public void spawnBuilding(){
		int rand = Random.Range (0, 3);
		if (rand > 0) {
			spawnPlainBuilding ();
		} else {
			raisedBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 2f));
		}
	}

	private void spawnPlainBuilding(){
		buildingPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, -8f));
	}
}
