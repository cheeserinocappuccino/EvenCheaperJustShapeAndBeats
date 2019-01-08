using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherGoOff : MonoBehaviour {

    public static bool letTeacherGo;
	void Start () {
        letTeacherGo = false;
        //this.transform.GetChild(0).gameObject.SetActive(false);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            letTeacherGo = true;
        }
        if (letTeacherGo == false)
        {
            

        }
        else if (letTeacherGo == true)
        {
            //this.transform.parent = null;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
	}
}
