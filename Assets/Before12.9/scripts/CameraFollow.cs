using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject Target;
    public int speed;

    //private Vector3 offset;
	// Use this for initialization
	void Start () {
        //offset = Target.transform.position - transform.position;
        //offset.z = 0;
	}
	
	// Update is called once per frame
	void Update () {

        //transform.position += (new Vector3(0, Target.transform.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0) - offset ) / speed;
        transform.position += (new Vector3(0, Target.transform.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0) ) / speed;
    }
}
