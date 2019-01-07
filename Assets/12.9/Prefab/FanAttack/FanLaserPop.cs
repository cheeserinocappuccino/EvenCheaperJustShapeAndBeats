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

    private bool dontCreateColliderTwice;
    public GameObject laserColliderObject;
    
    BoxCollider laserCloneBoxCollider;


    public float width;
    public int shrinkSpeed;

    private GameObject camera;
    private CameraShake cameraShake;
    void Start () {
        dontCreateColliderTwice = false;
       
        transform.position = transform.parent.transform.position;
        isPop = false;
        lineRenderer = GetComponent<LineRenderer>();
        wifiWarning = GetComponentInParent<WifiWarning>();
        nowPos[0] = new Vector3();
        nowPos[1] = new Vector3();

        camera = GameObject.FindGameObjectWithTag("Camera");
        cameraShake = camera.GetComponent<CameraShake>();
        
	}

    // Update is called once per frame
    void Update() {
        if (DJ.totalBeatCount - wifiWarning.startUpBeatCount >= earlyWaningBeat)
        {
            isPop = true;
            /*
            this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().material.color = new Color(this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().material.color.r,
                this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().material.color.g,
                this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().material.color.b, 0);*/
            this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
        if (isPop == true)
        {
            
            // 生成碰撞物
            if (dontCreateColliderTwice == false)
            {
                StartCoroutine(cameraShake.Shake(0.2f, 0.2f));
                laserCloneBoxCollider =  Instantiate(laserColliderObject,transform.position,transform.rotation).GetComponent<BoxCollider>();
                laserCloneBoxCollider.size = new Vector3(width, 100, 0);    // 不要讓他增加好了就維持固定大小
                dontCreateColliderTwice = true;

            }
                
            nowPos[0] += (targetPos[0] - lineRenderer.GetPosition(0)) / popSpeed;

            lineRenderer.SetPosition(0, nowPos[0]);

            nowPos[1] += (targetPos[1] - lineRenderer.GetPosition(1)) / popSpeed;

            lineRenderer.SetPosition(1, nowPos[1]);

            // 把雷射以及其判定慢慢縮小 
            laserCloneBoxCollider.size = new Vector3(width, 100, 0);
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            if (width > 0)
            {
                width -= Time.deltaTime/shrinkSpeed ;
            }
            else if (width <= 0)
            {
                Destroy(laserCloneBoxCollider.gameObject);
                Destroy(this.gameObject.transform.parent.gameObject);
            }
            
            
        }
    }
}
