using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	public float distance;
	
	// Update is called once per frame
	void Update(){
		Vector3 targetPosition = target.position;
		this.transform.position = new Vector3(
			targetPosition.x,
			targetPosition.y,
			targetPosition.z - distance
		);		
	}
}
