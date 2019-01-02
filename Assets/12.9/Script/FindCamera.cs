using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour {

    private Transform cameraTrans;

	void Start () {
        cameraTrans = GameObject.FindGameObjectWithTag("Camera").transform;
        transform.position = new Vector3(cameraTrans.transform.position.x,cameraTrans.transform.position.y,this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
