using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform groundCheck;
	public Transform obstacleCheck;

	float GROUND_RADIUS = 0.2f;
	float OBSTACLE_RADIUS = 0.2f;

	bool grounded = false;
	bool hasObstacle = false;

	public LayerMask whatIsGround;
	public LayerMask whatIsObstacle;

	float MAX_JUMP_FORCE = 700f;
	float jumpForce = 400f;
	Rigidbody2D rb;

	public Animator anim;

	bool touchLifted = false;
	bool isSlidingNow = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, GROUND_RADIUS, whatIsGround);
		hasObstacle = Physics2D.OverlapCircle (obstacleCheck.position, OBSTACLE_RADIUS, whatIsObstacle);
	}

	void Update() {

		if (gameObject.transform.position.y < -20) {
			MERun.playerFell ();
			return;
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			if (grounded && !isSlidingNow) {
				rb.AddForce (new Vector2 (0, jumpForce));
				touchLifted = false;
			}
		} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			//float currentForce = rb.velocity.magnitude;
			if (!isSlidingNow && jumpForce < MAX_JUMP_FORCE && !touchLifted) {
				float multiplier = jumpForce / 100f * 20f;
				rb.AddForce (new Vector2 (0, multiplier));
				jumpForce = jumpForce + 100;
				touchLifted = false;
			}
		} else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			//Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//			if (touchDeltaPosition.y < -1) {
			//				slide ();
			//			}

		} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			jumpForce = 400f;
			touchLifted = true;
		}

		if (hasObstacle) {
			MERun.playerCrashed ();
		}
	}

	public void slidePlayer() {
		if (!isSlidingNow) {
			anim.SetBool ("isSliding", true);
			isSlidingNow = true;
		}

	}

	public void stopSlidePlayer() {
		isSlidingNow = false;
		anim.SetBool ("isSliding", false);
	}
}
