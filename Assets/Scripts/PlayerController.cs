using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask whatIsGround;
	float maxJumpForce = 700f;
	float jumpForce = 400f;
	Rigidbody2D rb;
	float touchDuration = 0;
	bool touchLifted = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	}

	void Update() {
		if (grounded) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				rb.AddForce (new Vector2 (0, jumpForce));
				touchLifted = false;
			} 
		} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			//float currentForce = rb.velocity.magnitude;
			if (jumpForce < maxJumpForce && !touchLifted) {
				float multiplier = jumpForce / 100f * 20f;
				rb.AddForce (new Vector2 (0, multiplier));
				jumpForce = jumpForce + 100;
				touchLifted = false;
			}
		} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			jumpForce = 400f;
			touchLifted = true;
		}
	}
}
