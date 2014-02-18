using UnityEngine;
using System.Collections;

public class ShipControllerScript : MonoBehaviour {

	public float maxAcceleration;
	public float maxDeceleration;
	public float maxSpeed;
	public float minSpeed;
	public float maxTurnSpeed;

	private float speed = 0;
	private float targetSpeed = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float acceleration = Input.GetAxis ("Vertical");
		float turning = Input.GetAxis ("Horizontal") * maxTurnSpeed;

		// add the acceleration to the target speed
		targetSpeed += acceleration;

		// make sure our target speed is within our min and max speed
		targetSpeed = Mathf.Max (targetSpeed, minSpeed);
		targetSpeed = Mathf.Min (targetSpeed, maxSpeed);

		// check to see if the ship is being asked to stop
		if (Input.GetKey (KeyCode.Backspace)) {
			targetSpeed = 0;
		}

		if (speed < targetSpeed) {
			speed += maxAcceleration;
			speed = Mathf.Min (speed, targetSpeed);
		} else if (speed > targetSpeed) {
			speed += maxDeceleration;
			speed = Mathf.Max (speed, targetSpeed);
		}

		// rotate the ship
		rigidbody2D.transform.Rotate(0, 0, -turning);
			

		// accelerate the ship
		rigidbody2D.velocity = rigidbody2D.transform.up * speed;
	}
}
