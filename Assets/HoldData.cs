using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldData : MonoBehaviour {

    public static int gotHitTimes;
    public static int floorCount;
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        gotHitTimes = 0;
        floorCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
