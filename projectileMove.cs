using UnityEngine;
using System.Collections;

public class projectileMove : MonoBehaviour {
  
  // speed of the project, make value 1 or greater (in the inspector or set at start)
  public float speed;

	// Update is called once per frame
	void Update () {
		move ();
	}

	void move(){
		// projectile will move in its forward position at a multiple of the 'speed' variable
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
