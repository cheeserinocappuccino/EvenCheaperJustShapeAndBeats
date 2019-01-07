using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherCircleFlyout : MonoBehaviour {

    public Transform center;
    Vector3 a;
    // Use this for initialization
    void Start () {
        a = (transform.position - center.transform.position).normalized;
        //a = center.transform.position - transform.position;
        Debug.Log(a);
        transform.position += a;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
