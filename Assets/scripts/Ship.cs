using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public float maxAcceleration;
	public float maxDeceleration;
	public float maxSpeed;
	public float minSpeed;
	
	private float speed;
	private float targetSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
		updateSpeed ();
	}

	public void accelerateTargetSpeed(float amount) {
		setTargetSpeed (targetSpeed + amount);
	}

	public void setTargetSpeed(float value) {
		targetSpeed = value;

		// make sure our target speed is within our min and max speed
		targetSpeed = Mathf.Max (targetSpeed, minSpeed);
		targetSpeed = Mathf.Min (targetSpeed, maxSpeed);
	}

	public float getTargetSpeed() {
		return targetSpeed;
	}


	public float getSpeed() {
		return speed;
	}

	public void turnShip(float amount) {
		// rotate the ship
		rigidbody2D.transform.Rotate(0, 0, amount);
	}

	private void updateSpeed() {
		// adjust the speed toward our targetSpeed
		if (speed < targetSpeed) {
			speed += maxAcceleration;
			speed = Mathf.Min (speed, targetSpeed);
		} else if (speed > targetSpeed) {
			speed += maxDeceleration;
			speed = Mathf.Max (speed, targetSpeed);
		}

		// accelerate the ship
		rigidbody2D.velocity = rigidbody2D.transform.up * speed;
	}
}
