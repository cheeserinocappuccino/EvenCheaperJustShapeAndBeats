using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFingerToLaser : MonoBehaviour {

    private Transform fingerOrbTrans;
    private LineRenderer linerenderer;
	// Use this for initialization
	void Awake () {
        fingerOrbTrans = GameObject.FindGameObjectWithTag("TeacherFinger").transform;
        linerenderer = GetComponent<LineRenderer>();
        linerenderer.SetPosition(0, fingerOrbTrans.position);
        linerenderer.SetPosition(1, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
