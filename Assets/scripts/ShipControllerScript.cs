using UnityEngine;
using System.Collections;

public class ShipControllerScript : MonoBehaviour {

	public float maxSpeed = 10;
	public float minSpeed = -2;
	public float maxTurnSpeed = 6;

	private float speed = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float acceleration = Input.GetAxis ("Vertical");
		float turning = Input.GetAxis ("Horizontal") * maxTurnSpeed;

		speed += acceleration;
		speed = Mathf.Max (speed, minSpeed);
		speed = Mathf.Min (speed, maxSpeed);

		if (Input.GetKey (KeyCode.Backspace)) {
			speed = 0;
		}

		// rotate the ship
		rigidbody2D.transform.Rotate(0, 0, -turning);
			

		// accelerate the ship
		rigidbody2D.velocity = rigidbody2D.transform.up * speed;
	}
}
