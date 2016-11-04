using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private int timer;
	const int FLOOR_SPAWN_TIME = 150;
	const float MAX_WORLD_SPEED = 0.5f;
	const int FULL_RECOVER_TIME = 250;


	public EnvironmentSpawner environmentSpawner;
	public Text timerText;
	private static int recoverTimer = FULL_RECOVER_TIME;
	public static float worldSpeed = MAX_WORLD_SPEED;

	// Use this for initialization
	void Start () {
		//Camera.main.projectionMatrix = Matrix4x4.Ortho (-5.0f * 1.6f, 5.0f * 1.6f, -5.0f, 0.5f, 0.3f, 1000f);
		timer = 0;

		environmentSpawner.spawnBuilding ();

		//TODO need to spawn buildings slower 
		//playerCrashed ();
	}
	
	// Update is called once per frame
	void Update () {

		if (worldSpeed < MAX_WORLD_SPEED && recoverTimer % (FULL_RECOVER_TIME / 5) == 0) {
			worldSpeed += (MAX_WORLD_SPEED / 5);
		}
		if (recoverTimer < FULL_RECOVER_TIME) {
			recoverTimer++;
		}

		//TODO make this per second
		timerText.text = timer.ToString();

		timer++;

		if (timer % FLOOR_SPAWN_TIME == 0) {

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

	//TODO How do we determine if player has collided with an obstacle?
	public static void playerCrashed(){
		worldSpeed = 0;
		recoverTimer = 0;
	}
}
