using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject Target;
    public int speed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += (Target.transform.position - (transform.position + offset)) / 25;
        transform.position += (new Vector3(0, Target.transform.position.y, 0) - new Vector3(0, transform.position.y, 0 )) / speed;

    }
}
