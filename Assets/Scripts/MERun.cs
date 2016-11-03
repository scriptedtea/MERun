using UnityEngine;
using System.Collections;

public class MERun : MonoBehaviour {

	private int timer;
	const int OBSTACLE_TRIGGER_TIME = 360;
	public ObstacleSpawner obstacleSpawner;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer++;

		if (timer == OBSTACLE_TRIGGER_TIME) {
			
			obstacleSpawner.spawnObstacle ();
		}


		if (timer > 1000000) {
			timer = 0;
		}


	
	}
}
