using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private float timer;
	private static bool gameOver;
	public PlayerController player;

	const float MAX_WORLD_SPEED = 0.375f;

	float currentFloorSpawnTime;
	const int FULL_RECOVER_TIME = 200;

	public Text timerText;
	public Text distanceText;
	private static int recoverTimer = FULL_RECOVER_TIME;
	public static float worldSpeed = MAX_WORLD_SPEED;
	private float totalDistance;

	public static string finalTime;
	public static string finalDistance;

	// Use this for initialization
	void Start () {
		Camera.main.projectionMatrix = Matrix4x4.Ortho (-10.0f * 1.6f, 10.0f * 1.6f, -10.0f, 10.0f, 0.3f, 1000f);
		timer = 0;
		totalDistance = 0;
		gameOver = false;
		finalTime = "";
		finalDistance = "";

		playerCrashed ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameOver || totalDistance > 1000f) {
			worldSpeed = 0;
			finalTime = timerText.text.Substring(7);
			finalDistance = distanceText.text;
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
			return;
		}

		totalDistance += worldSpeed * 0.75f;
		distanceText.text = "Distance: " +((int)totalDistance).ToString (); 

		if ((worldSpeed < MAX_WORLD_SPEED) && (recoverTimer % (FULL_RECOVER_TIME / 5) == 0) && !player.hasObstacle) {
			worldSpeed += (MAX_WORLD_SPEED / 5);
		}
		if (recoverTimer < FULL_RECOVER_TIME) {
			recoverTimer++;
		}

		string minutes = ((int)timer / 60).ToString ();
		int secondsCount = (int)timer % 60;

		string seconds = "";
		if (secondsCount < 10) {
			seconds += "0";
		}
		seconds += secondsCount.ToString();

		string milliseconds = ((int) ((timer * 1000) % 1000)).ToString();
		string fulltime = minutes + ":" + seconds + "." + milliseconds;
		timerText.text = "Time : " + fulltime;

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
