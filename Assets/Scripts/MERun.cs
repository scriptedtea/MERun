using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private int timer;
	const int OBSTACLE_TRIGGER_TIME = 100;

	public ObstacleSpawner obstacleSpawner;
	public Text timerText;
	public static float worldSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//TODO make this per second
		timerText.text = timer.ToString();

		timer++;

		//TODO use modulo
		if (timer % OBSTACLE_TRIGGER_TIME == 0) {
			
			obstacleSpawner.spawnObstacle ();
		}


		//TODO fix this
		if (timer > 1000000) {
			timer = 0;
		}


	
	}
}
