using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class Songs
{
    public GameObject theSongArtPicture;
    public int sceneNum;
    public Vector3 tartgetPos;
}



public class Switch : MonoBehaviour {

    public List<Songs> songList = new List<Songs>();
    private int nowSelect = 0;
    
    // 按壓時的讀秒
    private float pressingTimer; // 按壓時的記秒
    public float pressHowLong; // 超過此數值時開始滑動
    private bool isHolding; // 用來判斷玩家是按壓還是單點
    private float scrollingTimer;
    public float scrollInterval;
    public int smoothValue;

    // 是否按了一開始的進入遊戲
    private bool enterMenu;

    // loading圖示
    public Image foxInner, foxOutter;
    private float waitToLoadTimer;
    public float waitSecondToLoad;
    private bool startSong;
    public Text loadingText;
    public GameObject loadingTextObject;
    private float progress; // 讀場景的進度

    void Start () {

        isHolding = false;
        enterMenu = false;
        scrollingTimer = 0;
        waitToLoadTimer = 0;
        startSong = false;
        progress = 0;
        for (int i = 0; i < songList.Count; i++)
        {
            songList[i].tartgetPos = new Vector3(2 * i, 0, 2 * i);

        }
            changeArtPos();
	}
	
	// Update is called once per frame
	void Update () {

        if (enterMenu == true)
        {
            PressingDetect();
            Selection();
            changeArtPos();
        }
        else
        {
            if (Input.anyKeyDown)
            {
                enterMenu = true;
            }


        }



    }

    public void changeArtPos()
    {
        for (int i = 0; i < songList.Count; i++)
        {
              
            songList[i].theSongArtPicture.transform.position +=  (songList[i].tartgetPos - songList[i].theSongArtPicture.transform.position) / smoothValue;


        }
    }

    public void IntoSong(int _sceneNum)
    {
        if (_sceneNum < SceneManager.sceneCountInBuildSettings)
        {
            
            StartCoroutine(LoadAsynchronously(_sceneNum));
        }

    }

    // Loading
    IEnumerator LoadAsynchronously(int _sceneNum)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneNum);
        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / .9f);
            loadingText.text = "Loading... " +(progress * 100).ToString() + " %";

            yield return null;

        }
        
    }
    public void ChooseRight()
    {
        if (nowSelect < songList.Count - 1)
        {
            nowSelect += 1;
            for (int i = nowSelect; i > 0; i--)     // 該移出畫面的先移出畫面
            {
                songList[i - 1].tartgetPos += new Vector3(-4, 0, -4);

                songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color = new Color(
                    songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color.r,
                    songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color.g,
                    songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color.b,
                    0.25f
                    );
            }
            for (int i = nowSelect; i < songList.Count; i++)    // 不該移出畫面的向前一步就好
            {
                songList[i].tartgetPos += new Vector3(-2, 0, -2);
            }
        }
    }

    public void ChoosLeft()
    {
        if (nowSelect > 0)
        {
            nowSelect -= 1;
            // 畫面外的向內一大步
            for (int i = nowSelect; i >= 0; i--)
            {
                songList[i].tartgetPos += new Vector3(4, 0, 4);

            }


            // 畫面內的向內一小步
            for (int i = nowSelect + 1; i < songList.Count; i++)
            {
                songList[i].tartgetPos += new Vector3(2, 0, 2);
                songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color = new Color(
                songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color.r,
                songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color.g,
                songList[i - 1].theSongArtPicture.GetComponent<SpriteRenderer>().material.color.b,
                1.0f
                );
            }

        }
    }

    public void PressingDetect()
    {
        if (Input.GetKey(KeyCode.U))
        {
            pressingTimer += Time.deltaTime;
            if (pressingTimer > pressHowLong)
            {
                isHolding = true;
            }

        }
        else if (Input.GetKeyUp(KeyCode.U))
        {
            pressingTimer = 0;
            isHolding = false;
            scrollingTimer = 0;
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            pressingTimer += Time.deltaTime;
            if (pressingTimer > pressHowLong)
            {
                isHolding = true;
            }

        }
        else if (Input.GetKeyUp(KeyCode.Y))
        {
            pressingTimer = 0;
            isHolding = false;
            scrollingTimer = 0;
        }

    }

    public void Selection()
    {
        // 短按時+1
        if (isHolding == false)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {

                ChooseRight();


            }

            else if (Input.GetKeyDown(KeyCode.Y))
            {

                ChoosLeft();


            }
        }
        else if (isHolding == true) // 長按時捲動
        {
            if (Input.GetKey(KeyCode.U))
            {
                scrollingTimer += Time.deltaTime;
                if (scrollingTimer >= scrollInterval)
                {
                    ChooseRight();
                    scrollingTimer = 0;
                }

            }

            else if (Input.GetKey(KeyCode.Y))
            {

                scrollingTimer += Time.deltaTime;
                if (scrollingTimer >= scrollInterval)
                {
                    ChoosLeft();
                    scrollingTimer = 0;
                }


            }
        }


        // 按空白建開始計時
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startSong = true;
            
            //IntoSong(songList[nowSelect].sceneNum);


        }

        if (startSong == true)
        {


            // 把歌單往下移開
            for (int i = 0; i < songList.Count; i++)
            {
                songList[i].tartgetPos = new Vector3(songList[i].tartgetPos.x, songList[i].tartgetPos.y - 10, songList[i].tartgetPos.z);
            }
            // 把狐狸移動到畫面中間
            float moveFoxinner = foxInner.GetComponent<RectTransform>().anchoredPosition.y;
            moveFoxinner += (0 - foxInner.GetComponent<RectTransform>().anchoredPosition.y ) / 25;
            foxInner.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,
                moveFoxinner,
                0
                );
            foxOutter.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,
                moveFoxinner,
                0
                );

            waitToLoadTimer += Time.deltaTime;
            if (waitToLoadTimer >= waitSecondToLoad / 3)
            {
                loadingTextObject.SetActive(true);
                loadingText.text = "Loading... " + (progress * 100).ToString() + " %";
            }
            if (waitToLoadTimer >= waitSecondToLoad)
            {
                IntoSong(songList[nowSelect].sceneNum);
                startSong = false;
            }

        }
    }

}

