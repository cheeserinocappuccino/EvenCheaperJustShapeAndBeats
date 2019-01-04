using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLaserPop : MonoBehaviour {

    private LineRenderer lineRenderer;
    public List<Vector3> targetPos = new List<Vector3>();
    private Vector3[] nowPos = new Vector3[2];
    public int popSpeed;
    private bool isPop;
    private WifiWarning wifiWarning;
    public int earlyWaningBeat;
	void Start () {
        transform.position = transform.parent.transform.position;
        isPop = false;
        lineRenderer = GetComponent<LineRenderer>();
        wifiWarning = GetComponentInParent<WifiWarning>();
        nowPos[0] = new Vector3();
        nowPos[1] = new Vector3();
	}

    // Update is called once per frame
    void Update() {
        if (DJ.totalBeatCount - wifiWarning.startUpBeatCount >= earlyWaningBeat)
        {
            isPop = true;
        }
        
        if (isPop == true)
        {
            nowPos[0] += (targetPos[0] - lineRenderer.GetPosition(0)) / popSpeed;

            lineRenderer.SetPosition(0, nowPos[0]);

            nowPos[1] += (targetPos[1] - lineRenderer.GetPosition(1)) / popSpeed;

            lineRenderer.SetPosition(1, nowPos[1]);
        }
    }
}
