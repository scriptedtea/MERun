using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private int timer;
	private static bool gameOver;
	const int MAX_FLOOR_SPAWN_TIME = 180;
	const float MAX_WORLD_SPEED = 0.4f;
	const int FULL_RECOVER_TIME = 200;


	public EnvironmentSpawner environmentSpawner;
	public Text timerText;
	private static int recoverTimer = FULL_RECOVER_TIME;
	public static float worldSpeed = MAX_WORLD_SPEED;

	// Use this for initialization
	void Start () {
		Camera.main.projectionMatrix = Matrix4x4.Ortho (-10.0f * 1.6f, 10.0f * 1.6f, -10.0f, 10.0f, 0.3f, 1000f);
		timer = 0;
		gameOver = false;

//		environmentSpawner.spawnBuilding ();
		environmentSpawner.spawnObstacle ();
		//TODO need to spawn buildings slower 
		//playerCrashed ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameOver) {
			worldSpeed = 0;
			Debug.Log ("DEAD!!!");
			return;
		}

		if (worldSpeed < MAX_WORLD_SPEED && recoverTimer % (FULL_RECOVER_TIME / 5) == 0) {
			worldSpeed += (MAX_WORLD_SPEED / 5);
		}
		if (recoverTimer < FULL_RECOVER_TIME) {
			recoverTimer++;
		}

		//TODO make this per second
		timerText.text = timer.ToString();

		timer++;

		//TODO Adjust spawner to account for worldspeed
		if (timer % MAX_FLOOR_SPAWN_TIME == 0) {

			int rand = Random.Range (1, 3);
			if (rand > 1) {
				environmentSpawner.spawnBuilding ();
			} else {
				environmentSpawner.spawnObstacle ();
			}
		}

		//TODO fix this
		if (timer > 1000000) {
			timer = 0;
		}
	}

	public static void playerCrashed(){
		worldSpeed = 0;
		recoverTimer = 0;
	}

	//End the game if player falls off building
	public static void playerFell(){
		gameOver = true;
	}
}
