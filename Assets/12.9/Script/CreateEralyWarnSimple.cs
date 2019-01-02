using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEralyWarnSimple : MonoBehaviour {

    private int startUpBeatCount;
    public int earlyWarningBeat;
    private int childNum;
    void Awake () {
        startUpBeatCount = DJ.totalBeatCount;
        childNum = transform.childCount;
        Debug.Log(childNum);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (DJ.totalBeatCount - (startUpBeatCount) == earlyWarningBeat)
        {
            
            for (int i = 0; i < childNum; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                
            }
            
        }

    }
}
