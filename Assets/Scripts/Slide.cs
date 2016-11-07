using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour {

	PlayerController p;

	public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void slide() {
		//Debug.Log ("Button is pressed");
		if (p == null) {
			p = player.GetComponent<PlayerController>();
		}
		p.slidePlayer();
		//p.resizeBoxCollider ();
	}

	public void stopSlide() {
		p.stopSlidePlayer();
		//p.resizeBoxCollider ();
	}
}
