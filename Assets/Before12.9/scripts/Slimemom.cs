using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimemom : MonoBehaviour {
    public GameObject center;
    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset =transform.position - center.transform.position ;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += ((center.transform.position - transform.position) + offset) ;
    }
}
