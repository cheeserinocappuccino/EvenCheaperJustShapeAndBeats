using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBoundary : MonoBehaviour {

    public float 
        leftBoundary, 
        rightBoundary, 
        topBoundary, 
        downBoundary, 
        zBoundary;

    public GameObject theCamera;
    private float cameraYorigin;
    private float toTopheight,toDownheight;
    
    // Use this for initialization
    void Start () {
        cameraYorigin = theCamera.transform.position.y;

        toTopheight = topBoundary - cameraYorigin;

        toDownheight = cameraYorigin - downBoundary;
	}
	
	// Update is called once per frame
	void Update () {
        topBoundary = theCamera.transform.position.y + toTopheight;
        downBoundary = theCamera.transform.position.y - toDownheight;
        //Debug.Log(topBoundary + "   " + downBoundary);

	}
}
