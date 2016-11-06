using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private float timer;
	private static bool gameOver;


	const float MAX_WORLD_SPEED = 0.4f;
	const int MAX_JUMP_UNITS = 25; //The longest distance between buildings that player can jump
	const int MAX_BUILDING_DISTANCE = 80; //The longest distance between two building sprites

	float currentFloorSpawnTime;
	const int FULL_RECOVER_TIME = 200;

	public Text timerText;
	private static int recoverTimer = FULL_RECOVER_TIME;
	public static float worldSpeed = MAX_WORLD_SPEED;

	// Use this for initialization
	void Start () {
		Camera.main.projectionMatrix = Matrix4x4.Ortho (-10.0f * 1.6f, 10.0f * 1.6f, -10.0f, 10.0f, 0.3f, 1000f);
		timer = 0;
		gameOver = false;

		playerCrashed ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameOver) {
			worldSpeed = 0;
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
			return;
		}

		if (worldSpeed < MAX_WORLD_SPEED && recoverTimer % (FULL_RECOVER_TIME / 5) == 0) {
			worldSpeed += (MAX_WORLD_SPEED / 5);
		}
		if (recoverTimer < FULL_RECOVER_TIME) {
			recoverTimer++;
		}

		//TODO make this per second
		int seconds 	 = (int)timer % 60;
		int milliseconds = (int) ((timer * 1000) % 1000);
		timerText.text = seconds.ToString () + "." + milliseconds.ToString ();;

		timer+= Time.deltaTime;

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
