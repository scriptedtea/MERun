using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private int timer;
	const int OBSTACLE_TRIGGER_TIME = 360;
	public ObstacleSpawner obstacleSpawner;
	public Text timerText;
	public int worldSpeed;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = timer.ToString();
		timer++;

		if (timer == OBSTACLE_TRIGGER_TIME) {
			
			obstacleSpawner.spawnObstacle ();
		}


		//TODO fix this
		if (timer > 1000000) {
			timer = 0;
		}


	
	}
}
