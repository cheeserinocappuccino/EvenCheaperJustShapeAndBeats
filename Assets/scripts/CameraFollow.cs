using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject Target;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = Target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += (Target.transform.position - (transform.position + offset)) / 25;
        transform.position += (new Vector3(0, Target.transform.position.y, 0) - new Vector3(0, transform.position.y, 0 ))/25;

    }
}
