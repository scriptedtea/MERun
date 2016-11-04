using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private Vector3 movementVector;

	// Use this for initialization
	void Start () {
		movementVector = new Vector3 (-MERun.worldSpeed, 0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(movementVector);
	}

	//TODO MERun calls this for every Obstacle when we need to change world speed

}
