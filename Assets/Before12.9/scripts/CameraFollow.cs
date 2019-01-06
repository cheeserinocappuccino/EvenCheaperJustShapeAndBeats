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
        /*if (DJ.gameStart)
        {
            transform.position += (new Vector3(0, Target.transform.position.y, 0) - new Vector3(0, transform.position.y, 0)) / speed;
        }*/

        transform.position += (new Vector3(0, Target.transform.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0)) / speed;
    }
}
