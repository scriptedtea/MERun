using UnityEngine;
using System.Collections;

public abstract class Environment : MonoBehaviour {

	private const int RECYCLE_DISTANCE = 150;
	private Vector3 movementVector;
	private float lastWorldSpeed;
	private float distanceTraveled;

	// Use this for initialization
	void Start () {
		matchWorldSpeed ();
		distanceTraveled = 0;
	}
		
	// Update is called once per frame
	protected void Update () {
		if (MERun.worldSpeed != lastWorldSpeed) {
			matchWorldSpeed ();
		}

		//TODO PUT THESE BACK WHEN SLIDE WORKS
		//transform.Translate(movementVector);
		//distanceTraveled -= movementVector.x;
		if (distanceTraveled > RECYCLE_DISTANCE) {
			gameObject.Recycle ();
		}
	}

	private void matchWorldSpeed(){
		movementVector = new Vector3 (-MERun.worldSpeed, 0,0);
		lastWorldSpeed = MERun.worldSpeed;
	}

	//TODO MERun calls this for every Obstacle when we need to change world speed
}
