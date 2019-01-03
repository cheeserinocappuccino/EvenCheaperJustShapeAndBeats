using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEarlyWarning : MonoBehaviour {
    private GameObject djObject;
    private DJ thedjScript;

    private int startUpBeatCount;
    private bool isFading = false; // 生成傷害後預警物件慢慢消失
    public int earlyWarningBeat;


    //-------------
    public GameObject gameController; // 存放目前動態邊界的物件;

    private float spawnYTop, spawnYMin, spawnXLeft, spawnXRight, spawnz; // 這個物件生成時會移動到這些變數所存的位置;

    private HoldBoundary theBoundary; // 動態邊界;

    private LineRenderer laser; // 這個物件所掛的linerenderer


    public float laserLength; // 雷射射出的距離

    public float laserTargetLength; // 雷射的目標距離 只會是laserlenth的正數或負數
    //-------------------

    private GameObject theRealAttack;
    private GameObject thisSelf;
    public float dieSpeed;

    private Color alphaColor;

    public bool isRandom;
    public bool isBothSided;
    // Use this for initialization
    void Awake () {
        laserTargetLength = -laserLength;
        thisSelf = this.gameObject;
        djObject = GameObject.FindGameObjectWithTag("DJ");
        thedjScript = djObject.GetComponent<DJ>();
        startUpBeatCount = DJ.totalBeatCount;
        if (isRandom == true)
        {
            SpawnBehaveRandomly();
        }
        else
        {
            SpawnBehaveStatic();
        }

        alphaColor = this.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;

        Destroy(thisSelf, dieSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        if (DJ.totalBeatCount - (startUpBeatCount) == earlyWarningBeat)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            isFading = true;
            

        }

        if (isFading == false)
        {
            alphaColor.a = Mathf.Lerp(alphaColor.a, 0.5f, 1.0f * Time.deltaTime);
        }
        else if (isFading == true)
        {
            alphaColor.a = 0.0f;
        }
        this.GetComponent<MeshRenderer>().material.color = alphaColor;
        //this.GetComponent<MeshRenderer>().material.color = Color.Lerp( alphaColor, this.GetComponent<MeshRenderer>().material.color, 20f * Time.deltaTime);

    }

    public void SpawnBehaveRandomly()
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
        spawnXLeft = theBoundary.leftBoundary;  // 預設左邊出現
        spawnXRight = theBoundary.rightBoundary;
        laserTargetLength = -laserLength;
        /*
        int leftOrRight = Random.Range(0, 2);    // 選擇是左邊還是右邊出現;
        if (leftOrRight == 1)   // 如果random到另一邊 要改生成的x還有雷射的噴發目標為原本的負數
        {
            spawnX = theBoundary.rightBoundary;
            laserTargetLength = -laserLength;
        }*/

        //Debug.Log(leftOrRight);
        // 將腳本附掛的物件位置移到現在的邊界上的隨機點;


        // transform.position = new Vector3(spawnX, Random.Range(spawnYMin, spawnYTop), spawnz);
        transform.position = new Vector3(Random.Range(spawnXLeft,spawnXRight) ,spawnYTop, spawnz);




    }
    public void SpawnBehaveStatic()
    {
        


    }
}

