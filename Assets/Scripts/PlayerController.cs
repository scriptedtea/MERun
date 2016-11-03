using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public Rigidbody2D rb;

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
			}
		}
	}
}
