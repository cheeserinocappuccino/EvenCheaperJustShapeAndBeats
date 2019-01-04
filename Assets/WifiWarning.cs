using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiWarning : MonoBehaviour {

    public int startUpBeatCount;
    public int earlyWarningBeat;
    private int childNum;

    private bool startToPop;
    private float popingtimer;
    public float poptimerInterval;
    private int a;


    void Awake()
    {
        startUpBeatCount = DJ.totalBeatCount;
        childNum = transform.childCount;
        Debug.Log(childNum);
        a = 0;
 
    }

 
    void Update()
    {

        if (DJ.totalBeatCount - (startUpBeatCount) == earlyWarningBeat && startToPop == false)
        {
            startToPop = true;
        }

        if (startToPop == true)
        {
            popingtimer += Time.deltaTime;
            if (popingtimer >= poptimerInterval && a < transform.childCount)
            {

                transform.GetChild(a).gameObject.SetActive(true);

                a++;
                popingtimer = 0.0f;
                
            }
        }
    }
}
