using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {


    Rigidbody rb;

    // name the horizontal axis
    public string horizontalAxis;

    // select forward button
    public KeyCode forwardButton;

    public float thrustVal = 10f;
    float thrust;

    // the direction of rotation
    float dir;

    // the amount of rotation
    public Vector3 eulerAngle;

    // Use this for initialization
    void Start () {
        // references the rigidbody attached to the GameObject
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        getInput ();
        rotate ();
    }

    void FixedUpdate(){
        moveForward ();
    }

    void getInput(){
        // when Player pressed W key, set forward thrust
        if (Input.GetKey (forwardButton)) {
            thrust = thrustVal;
        } else {
            thrust = 0f;
        }
        // negative val rotates left, postive rotates right
        dir = Input.GetAxis(horizontalAxis);
        print (dir);
    }

    void moveForward(){
        rb.AddForce (transform.forward * thrust); 
    }

    void rotate(){
        Quaternion deltaRotation = Quaternion.Euler (eulerAngle * Time.deltaTime * dir);
        rb.MoveRotation (rb.rotation * deltaRotation);
    }
}
