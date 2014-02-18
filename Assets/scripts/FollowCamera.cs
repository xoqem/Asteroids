using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform target;
	public float distance;
	
	// Update is called once per frame
	void Update(){
		Vector3 targetPosition = target.position;
		transform.position = new Vector3(
			targetPosition.x,
			targetPosition.y,
			targetPosition.z - distance
		);
	}
}
