using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MERun : MonoBehaviour {

	private int timer;
	const int FLOOR_SPAWN_TIME = 100;


	public EnvironmentSpawner environmentSpawner;
	public Text timerText;
	public static float worldSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		//Camera.main.projectionMatrix = Matrix4x4.Ortho (-5.0f * 1.6f, 5.0f * 1.6f, -5.0f, 0.5f, 0.3f, 1000f);
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

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
}
