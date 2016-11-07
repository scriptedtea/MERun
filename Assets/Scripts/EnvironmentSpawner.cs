using UnityEngine;
using System.Collections;

public class EnvironmentSpawner : MonoBehaviour {

	//Obstacle prefabs
	public static Building buildingPrefab;
	public static Box boxPrefab;
	public static RaisedBoxesBuilding raisedBoxesPrefab;
	public static SlideBox slideBoxPrefab;
	public static RedBox redBoxPrefab;

	private const float SPAWN_OFFSET_X = 80;

	private static bool nextBuildingIsAssisted = false;

	// Use this for initialization
	void Start () {
		//TODO there might be a better way to implement this...
		buildingPrefab 		= (Building)Resources.Load ("Prefabs/Building", typeof(Building));
		raisedBoxesPrefab 	= (RaisedBoxesBuilding)Resources.Load ("Prefabs/RaisedBoxesBuilding", typeof(RaisedBoxesBuilding));

		boxPrefab 			= (Box)Resources.Load ("Prefabs/Box",  typeof(Box));
		slideBoxPrefab 		= (SlideBox)Resources.Load ("Prefabs/SlideBox", typeof(SlideBox));
		redBoxPrefab 		= (RedBox)Resources.Load ("Prefabs/RedBox", typeof(RedBox));
	}



	public static void spawnEnvironment(){
		int whichObstacle = Random.Range (0, 4);
		int whichBuilding = Random.Range (0, 2);
		int whichAid = Random.Range (0, 2);

		switch (whichObstacle) {
		case 0:
		case 1:
			spawnBox ();
			break;
		case 2:
			spawnSlideBox ();
			spawnPlainBuilding ();
			return;
		}

		switch (whichBuilding) {
		case 0:
			spawnPlainBuilding ();
			break;
		case 1:
			spawnRaisedBoxesBuilding ();
			break;
		}


		switch (whichAid) {
		case 1:
			spawnDoubleAid ();
			break;
		}
	}


	private static void spawnAid(){
		int redBoxOffset = 25;
		redBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X + redBoxOffset, -1.75f));
		nextBuildingIsAssisted = true;
	}
	private static void spawnDoubleAid(){
		int redBoxOffset = 15;
		redBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X + redBoxOffset, -1.75f));
		spawnAid ();

	}

	private static void spawnBox(){
		int boxOffset = -1;
		boxPrefab.Spawn(new Vector3 (SPAWN_OFFSET_X + boxOffset, -1.5f));
	}

	private static void spawnSlideBox(){
		slideBoxPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 5));
	}

	private static void spawnPlainBuilding(){
		buildingPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, -8f));
	}

	private static void spawnRaisedBoxesBuilding(){
		raisedBoxesPrefab.Spawn (new Vector3 (SPAWN_OFFSET_X, 2f));
	}
}
