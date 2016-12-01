using UnityEngine;
using System.Collections;

public class Zombie_Chase : MonoBehaviour {

	public float rotationSpeed = 1f;
	public float movementSpeed = 1f;
	Transform target;

	public float closenessMax  = 2f;

	void OnTriggerStay(Collider collider){
		if (collider.CompareTag ("Player")) {
			target = collider.transform;
			rotateToward ();
			moveToward ();
		}
	}

	void rotateToward(){
		Vector3 targetDir = target.position - transform.position;
		float rotate = rotationSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, rotate, 0.0F);
		transform.rotation = Quaternion.LookRotation (newDir);
	}

	void moveToward(){
		if (Vector3.Distance(target.position, transform.position) > closenessMax) {
			transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed);
		}
	}
}
