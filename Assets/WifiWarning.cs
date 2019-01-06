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

    private GameObject camera;
    private HoldBoundary holdBoundary;
    void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("Camera");
        holdBoundary = camera.GetComponent<HoldBoundary>();
        
        startUpBeatCount = DJ.totalBeatCount;
        childNum = transform.childCount;
        Debug.Log(childNum);
        a = 0;
 
    }
    private void Start()
    {
        //this.transform.position = new Vector3(transform.position.x, holdBoundary.downBoundary, transform.position.z);
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
