using UnityEngine;
using System.Collections;

public class EnvironmentSpawner : MonoBehaviour {

	//Obstacle prefabs
	public static Building buildingPrefab;
	public static Box boxPrefab;
	public static RaisedBoxesBuilding raisedBoxesPrefab;
	public static SlideBox slideBoxPrefab;

	//TODO refactor back to int?
	private const float SPAWN_OFFSET_X = 75;

	// Use this for initialization
	void Start () {
		//TODO there might be a better way to implement this...
		buildingPrefab 		= (Building)Resources.Load ("Prefabs/Building", typeof(Building));
		raisedBoxesPrefab 	= (RaisedBoxesBuilding)Resources.Load ("Prefabs/RaisedBoxesBuilding", typeof(RaisedBoxesBuilding));

		boxPrefab 			= (Box)Resources.Load ("Prefabs/Box",  typeof(Box));
		slideBoxPrefab 		= (SlideBox)Resources.Load ("Prefabs/SlideBox", typeof(SlideBox));
	}

	public static void spawnEnvironment(){
		int rand = Random.Range (1, 3);
		if (rand > 1) {
			spawnBuilding ();
		} else {
			spawnObstacle ();
		}
	}
	
	private static void spawnObstacle(){

		int rand = Random.Range (0, 2);
		if (rand > 0) {
			int boxOffset = -1;
			boxPrefab.Spawn(new Vector3 (SPAWN_OFFSET_X + boxOffset, -1.5f));
			spawnPlainBuilding ();
		} else {

			slideBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 3));
			spawnPlainBuilding ();
		}


	}

	public static void spawnBuilding(){
		int rand = Random.Range (0, 4);
		if (rand > 0) {
			spawnPlainBuilding ();
		} else {
			raisedBoxesPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 2f));
		}
	}

	private static void spawnPlainBuilding(){
		buildingPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, -8f));
	}
}
