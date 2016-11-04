using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour {

	public bool isSlidingnow = false;
	float slidingDuration = 0f;

	PlayerController p;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//checkSlide ();
	}

	public void slide() {
		Debug.Log ("Button is pressed");
		if (p == null) {
			GameObject player = GameObject.Find ("Player");
			p = player.GetComponent<PlayerController>();
		}
		if (!isSlidingnow) {
			p.GetComponent<Animator> ().SetBool ("isSliding", true);
			isSlidingnow = true;
		}
	}

	public void stopSlide() {
		isSlidingnow = false;
		p.GetComponent<Animator> ().SetBool ("isSliding", false);
		slidingDuration = 0;
	}

//	void checkSlide() {
//		if (isSlidingnow) {
//			if (slidingDuration > 20) {
//				isSlidingnow = false;
//				p.GetComponent<Animator> ().SetBool ("isSliding", false);
//				slidingDuration = 0;
//				return;
//			} else {
//				slidingDuration++;
//			}
//		}
//	}
}
