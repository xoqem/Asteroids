using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public Ship ship;
	public float turnSpeedScale;

	// Update is called once per frame
	void FixedUpdate () {
		float acceleration = Input.GetAxis ("Vertical");
		float turning = Input.GetAxis ("Horizontal") * turnSpeedScale;
		
		// check to see if the ship is being asked to stop
		if (Input.GetKey (KeyCode.Backspace)) {
			ship.setTargetSpeed (0);
		} else {
			// otherwise add the acceleration to the target speed
			ship.accelerateTargetSpeed (acceleration);
		}
		
		ship.turnShip (-turning);
	}
}
