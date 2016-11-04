using UnityEngine;
using System.Collections;

public abstract class Environment : MonoBehaviour {

	private Vector3 movementVector;
	private int distanceTraveled;

	// Use this for initialization
	void Start () {
		movementVector = new Vector3 (-MERun.worldSpeed, 0,0);
		distanceTraveled = 0;
	}

	// Update is called once per frame
	void Update () {
		
		transform.Translate(movementVector);
		distanceTraveled++;
		if (distanceTraveled > 300) {
			gameObject.Recycle ();
		}
	}

	//TODO MERun calls this for every Obstacle when we need to change world speed
}
