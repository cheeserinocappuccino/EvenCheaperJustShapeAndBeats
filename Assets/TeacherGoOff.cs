using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherGoOff : MonoBehaviour {

    public static bool letTeacherGo;
    private bool dontDotwice;
	void Start () {
        dontDotwice = false;
        letTeacherGo = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        
        
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
        else if (letTeacherGo == true && dontDotwice == false)
        {
            //this.transform.parent = null;
            this.transform.GetChild(0).gameObject.SetActive(true);
            dontDotwice = true;
        }
	}
}
