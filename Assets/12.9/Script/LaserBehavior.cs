using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    public GameObject gameController; // 存放目前動態邊界的物件;
    private GameObject earlyWarningObject;
    private CreateEarlyWarning mycreateEarlywarning;

    private float spawnYTop, spawnYMin, spawnX, spawnz; // 這個物件生成時會移動到這些變數所存的位置;

    private HoldBoundary theBoundary; // 動態邊界;

    private LineRenderer laser; // 這個物件所掛的linerenderer
    

    public float laserLength; // 雷射射出的距離

    private float laserTargetLength; // 雷射的目標距離 只會是laserlenth的正數或負數

    public float explodeSpeed; // 類似smooothCam的/25 值越大越慢
    private float x; // 雷射的position當下的x值

    public int ealyWarning ;


    public GameObject thisSelf; // 刪除的時候刪除自己
    public float dieSpeed;

    public GameObject laserColliderObject;
    private BoxCollider laserCloneBoxCollider;
	// Use this for initialization
	void Awake () {
        earlyWarningObject = transform.parent.gameObject;
        mycreateEarlywarning = earlyWarningObject.GetComponent<CreateEarlyWarning>();
        transform.position = earlyWarningObject.transform.position;
        laserTargetLength = mycreateEarlywarning.laserTargetLength;

        thisSelf = this.gameObject;
        laser = GetComponent<LineRenderer>();
       
        //SpawnBehave();
        x = 0;


          laserCloneBoxCollider = Instantiate(laserColliderObject, new Vector3(earlyWarningObject.transform.position.x, earlyWarningObject.transform.position.y,0), transform.rotation).GetComponent<BoxCollider>();

          laserCloneBoxCollider.size = new Vector3(1, 300, 0);    // 不要讓他增加好了就維持固定大小
        
    


        Destroy(thisSelf,dieSpeed); // 感覺這個要對拍但目前先這樣;
        Destroy(laserCloneBoxCollider.gameObject, dieSpeed);

    }
	
	// Update is called once per frame
	void Update () {
        if (laser.GetPosition(1).x != laserTargetLength)
        {
            x += (laserTargetLength - laser.GetPosition(1).y) / explodeSpeed;

            if (mycreateEarlywarning.isBothSided == true)
            {
                laser.SetPosition(0, new Vector3(0, -x, 0));
            }
            laser.SetPosition(1, new Vector3(0, x, 0));


        }

	}

    public void SpawnBehave()
    {
        // 取得現在的邊界資訊
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
        theBoundary = gameController.GetComponent<HoldBoundary>();
        spawnYTop = theBoundary.topBoundary;
        spawnYMin = theBoundary.downBoundary;
        spawnz = theBoundary.zBoundary;
        spawnX = theBoundary.leftBoundary;  // 預設左邊出現
        laserTargetLength = laserLength;
        int leftOrRight = Random.Range(0, 2);    // 選擇是左邊還是右邊出現;
        if (leftOrRight == 1)   // 如果random到另一邊 要改生成的x還有雷射的噴發目標為原本的負數
        {
            spawnX = theBoundary.rightBoundary;
            laserTargetLength = -laserLength;
        }

        //Debug.Log(leftOrRight);
        // 將腳本附掛的物件位置移到現在的邊界上的隨機點;


        transform.position = new Vector3(spawnX, Random.Range(spawnYMin, spawnYTop), spawnz);

        



    }
}
