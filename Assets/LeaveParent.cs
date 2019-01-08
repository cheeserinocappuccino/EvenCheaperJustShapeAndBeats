using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveParent : MonoBehaviour {

    public GameObject deleteTeacherOld;
	void Start () {
        transform.parent = null;
        Destroy(deleteTeacherOld);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
