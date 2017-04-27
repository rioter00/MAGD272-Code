using UnityEngine;
using System.Collections;

public class LerpRotation : MonoBehaviour {
	// use this script to control a rotation of an object, to turn and face a target object
	// Reference Unity's API: https://docs.unity3d.com/ScriptReference/Quaternion.Lerp.html
	Quaternion targetRotation;

	public Transform target;			// target object 
	public float speed = 0.1F;			// speed scaling factor

	bool rotating = false;				// toggles the rotation, after targeting, toggle true, false after arrives

	float rotationTime; // when rotationTime == 1, will have rotated to our target

	void Update() {

		// Target Phase
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 relativePosition = target.position - transform.position;
			targetRotation = Quaternion.LookRotation (relativePosition);
			rotating = true;
			rotationTime = 0;
		}

		// Rotation Phase
		if (rotating) {
			rotationTime += Time.deltaTime * speed;
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, rotationTime);
			if (rotationTime > 1) {
				rotating = false;
			}
		}
	}
}
