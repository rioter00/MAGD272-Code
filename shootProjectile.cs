using UnityEngine;
using System.Collections;

public class shootProjectile : MonoBehaviour {

  // variable to link the prefab to be instantiated
	public GameObject projectilePrefab;

	// distance (as multiple) in front of shooter which the prefab will spawn
	public float offset;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){    // set the keycode to the button you want to shoot with.
			shoot();
		}
	}

	void shoot(){
    Instantiate (projectilePrefab, transform.position + (transform.forward * offset) , transform.rotation) ;
	}
}
