using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;




[System.Serializable]
public class EveryNotes
{

    
    public int beatCount;
    public int earlyWarning;
    public string[] attackType;




}



[System.Serializable]
public class Notesheet {



    public EveryNotes[] myEveryNotes;

    





}

[System.Serializable]
public class AttackTypes {

    
    public GameObject topRandomlaser; // 頂端隨機雷射物件
    public GameObject squareLaser; // 自訂位置雷射物件(方形)

}



public class DJ : MonoBehaviour {
    // BPM 174
    // 0.0862068




    private AudioSource theMainSongAudioSource;
    private float lastBeat;
    public float quarterNoteTime;
    public GameObject floor;
    public GameObject beatCircle;

    public float beatOffset;
    // 測試節奏用的TExt
    public Text bpmText;
    public static int totalBeatCount;
    int _lastBeatCountsimple = -1; // 給節奏圈不要重複跑用的
    bool musicPlay = false; // 給音樂不要重複跑用的



    // 讀樂譜用的變數
    Notesheet loadNotes = new Notesheet();
    Notesheet loadNotesFloor = new Notesheet(); // 讀簡單譜用的
    StreamReader file;
    StreamReader fileFloor; // 讀簡單譜用的
    string loadJson;
    string loadJsonFloor; // 讀簡單譜用的
    int totalmeasure;
    int noteCount;
    int noteCountSimple;

    //生成平台的位置
    public Transform floorCreater;
    public float firstFloorY,secondFloorY;

    // 去抓第一個平台的位置
    public GameObject theLastFloor;
    public GameObject nowTargetFloor;


    // 分數text
    public Text scoreText;
    public static int score;

    public AttackTypes myAttackTypes = new AttackTypes();

    // 別一開始就跑
    public bool gameStart = false;

    void Awake () {
        theMainSongAudioSource = GetComponent<AudioSource>();
        lastBeat = 0 + beatOffset;
        totalBeatCount = 0;

        WhatisThis();
        totalmeasure = 0;
        noteCount = 0;
        noteCountSimple = 0;

        //Debug.Log(loadNotes.myEveryNotes.Length);
        theLastFloor = floorCreater.gameObject;
        nowTargetFloor = theLastFloor;

        score = 0;
        scoreText.text = string.Format("{0:00}", score);
	}



    void FixedUpdate () {

        if (Input.GetKey(KeyCode.T))
        {
            gameStart = true;
        }

        // 
        if (gameStart == true)
        {
            if (musicPlay == false)
            {
                theMainSongAudioSource.Play();
                musicPlay = true;
            }
            BeatCount();
            

            totalmeasure = totalBeatCount / 32;

            try
            {
                Attack(loadNotes.myEveryNotes[noteCount].beatCount, loadNotes.myEveryNotes[noteCount].earlyWarning, loadNotes.myEveryNotes[noteCount].attackType);

            }
            catch
            {
                Debug.Log("已超出樂譜長度或是忘記拉近hirerachy");
            }

            try
            {
                BeatCircleBehave(loadNotesFloor.myEveryNotes[noteCountSimple].beatCount, 8);
            }
            catch
            {
                Debug.Log("簡單譜出錯");
            }


        }
    }


    public void BeatCount()
    {
        //Debug.Log(theMainSongAudioSource.time);
        if (theMainSongAudioSource.time - lastBeat >= quarterNoteTime)
        {
            //Debug.Log(theMainSongAudioSource.time - lastBeat + "  totalBeatCount:  " + totalBeatCount);

            // 如果因為update的關係造成落差 在下一次節拍修正
            if (theMainSongAudioSource.time - lastBeat != quarterNoteTime)
            {
                lastBeat = theMainSongAudioSource.time - ((theMainSongAudioSource.time - lastBeat) - quarterNoteTime);
            }
            else
            {
                lastBeat = theMainSongAudioSource.time;
            }

            totalBeatCount += 1;


            //bpmText.text = totalBeatCount + "   " + (totalBeatCount / 4) / 4 + "   " + totalBeatCount / 4 % 4 + "   " + totalBeatCount % 4 + "";


        }


        


    }


    public void WhatisThis()
    {
        
        loadNotes.myEveryNotes = new EveryNotes[9999];
        loadNotesFloor.myEveryNotes = new EveryNotes[9999];
        file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "TitanNotes.json"));
        fileFloor = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "simple.json"));
        loadJson = file.ReadToEnd();
        loadJsonFloor = fileFloor.ReadToEnd();
        file.Close();
        fileFloor.Close();
        

        loadNotes = JsonUtility.FromJson<Notesheet>(loadJson); // 手動讀這一層就好 下一層交給Notes class中的myMeasurements 因為命名一樣的關係json會自動讀到
        loadNotesFloor = JsonUtility.FromJson<Notesheet>(loadJsonFloor);

        //命名有差 目標變數名稱跟鍵要同名 
        // 注意一下json檔案的階層數 如果讀不到可能是因為json檔多包了一階沒用的階層
    }


    public void Attack(int _beatCount, int _earlyWarning, string[] _attackType)
    {
        //Debug.Log((_beatCount - _earlyWarning) + "   " + totalBeatCount);
        
        
        if (totalBeatCount == _beatCount - _earlyWarning || _beatCount == 0)
        {

            for (int i = 0; i < _attackType.Length; i++)
            {
                if (_attackType[i] == "laser")
                {
                    Instantiate(myAttackTypes.topRandomlaser);
                 
                }
                else if (_attackType[i] == "laserDouble")
                {
                    Instantiate(myAttackTypes.topRandomlaser);
            
                }
                else if (_attackType[i] == "laserMany")
                {
                    Instantiate(myAttackTypes.squareLaser);


                }
                
            }
            
            noteCount += 1;
        }

        //Debug.Log(loadNotes.myMeasurements[measure].beatCount);
    }

    public void BeatCircleBehave(int _beatCount, int _earlyWarning)
    {
        
        
        if (totalBeatCount == _beatCount || _beatCount == 0)
        {
            //theLastFloor = GameObject.FindGameObjectWithTag
            if (_beatCount == 0)
            {
                noteCountSimple += 1;
            }
            else
            {
                
               nowTargetFloor = Instantiate(floor, new Vector3(theLastFloor.transform.position.x, theLastFloor.transform.position.y - 7, theLastFloor.transform.position.z), transform.rotation);
                noteCountSimple += 1;
            }
        }
        //Debug.Log(totalBeatCount + "  " + _beatCount);
        if (totalBeatCount == _beatCount - _earlyWarning || _beatCount == 0 )
        {
            
            if (_beatCount != 0 && _lastBeatCountsimple != _beatCount)
            {
                Instantiate(beatCircle);
               
                _lastBeatCountsimple = _beatCount;// 存入現在的_beatcount讓他不要同一拍重複生成
            }
            

        }
        



    }

    public  void ScoreChange(int _score)
    {
        score += _score;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = string.Format("{0:00}",score);
        scoreText.GetComponent<Animator>().SetTrigger("Plussing");

    }


}
