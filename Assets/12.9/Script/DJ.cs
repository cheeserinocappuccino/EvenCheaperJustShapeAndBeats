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
    public string attackType;




}



[System.Serializable]
public class Notesheet {



    public EveryNotes[] myEveryNotes;

    





}



public class DJ : MonoBehaviour {
    // BPM 174
    // 0.0862068




    private AudioSource theMainSongAudioSource;
    private float lastBeat;
    public float quarterNoteTime;

    public float beatOffset;
    // 測試節奏用的TExt
    public Text bpmText;
    private int totalBeatCount;

    // 雷射物件
    public GameObject laser;
    public GameObject laserSlow;

    // 讀樂譜用的變數
    Notesheet loadNotes = new Notesheet();
    StreamReader file;
    string loadJson;
    int totalmeasure;
    int noteCount;


    void Awake () {
        theMainSongAudioSource = GetComponent<AudioSource>();
        lastBeat = 0 + beatOffset;
        totalBeatCount = 0;

        WhatisThis();
        totalmeasure = 0;
        noteCount = 0;

        Debug.Log(loadNotes.myEveryNotes.Length);
        
	}



    void FixedUpdate () {



        // 如果該節有被標記才跑?
        BeatCount();

        totalmeasure = totalBeatCount / 32;

        try
        {
            Attack(loadNotes.myEveryNotes[noteCount].beatCount, loadNotes.myEveryNotes[noteCount].earlyWarning, loadNotes.myEveryNotes[noteCount].attackType);

        }
        catch {
            Debug.Log("已超出樂譜長度");
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


            bpmText.text = totalBeatCount + "   " + (totalBeatCount / 4) / 4 + "   " + totalBeatCount / 4 % 4 + "   " + totalBeatCount % 4 + "";


        }


        


    }


    public void WhatisThis()
    {
        
        loadNotes.myEveryNotes = new EveryNotes[9999];
        file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "tryMani.json"));
        loadJson = file.ReadToEnd();
        file.Close();

        loadNotes = JsonUtility.FromJson<Notesheet>(loadJson); // 手動讀這一層就好 下一層交給Notes class中的myMeasurements 因為命名一樣的關係json會自動讀到

       //loadNotes.myMeasurements = JsonUtility.FromJson<Measurements[]>(loadJson);  //我操直接加個中掛號就沒事了喔
        //myMeasurements = JsonUtility.FromJson<Measurements>(loadJson);
        //Debug.Log(loadNotes.myMeasurements[0].earlyWarning);
        //Debug.Log(loadNotes.myMeasurements[0].earlyWarning);


        //命名有差 目標變數名稱跟鍵要同名 
        // 注意一下json檔案的階層數 如果讀不到可能是因為json檔多包了一階沒用的階層
    }


    public void Attack(int _beatCount, int _earlyWarning, string _attackType)
    {
        if (_beatCount == totalBeatCount)
        {
            if (_attackType == "laser")
            {
                Instantiate(laser);
                Debug.Log("雷射!");
            }
            else if (_attackType == "laserMany")
            {
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);
                Instantiate(laserSlow);

            }
            noteCount += 1;
        }

        //Debug.Log(loadNotes.myMeasurements[measure].beatCount);
    }

    

    
}
