using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;



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
	
	void Awake () {
        theMainSongAudioSource = GetComponent<AudioSource>();
        lastBeat = 0 + beatOffset;
        totalBeatCount = 0;
	}



    void FixedUpdate () {



        // 如果該節有被標記才跑?

        //Debug.Log(theMainSongAudioSource.time);
        if ( theMainSongAudioSource.time - lastBeat >= quarterNoteTime)
        {
            //Debug.Log(theMainSongAudioSource.time - lastBeat + "  totalBeatCount:  " + totalBeatCount);

            // 如果因為update的關係造成落差 在下一次節拍修正
            if (theMainSongAudioSource.time - lastBeat != quarterNoteTime)
            {
                lastBeat = theMainSongAudioSource.time - ( (theMainSongAudioSource.time - lastBeat) - quarterNoteTime);
            }
            else {
                lastBeat = theMainSongAudioSource.time;
            }
            //Debug.Log(lastBeat);
            totalBeatCount += 1;


            /*
            Debug.Log(theMainSongAudioSource.time + "music");
            Debug.Log(lastBeat + "music2");*/

            bpmText.text = totalBeatCount + "   " + (totalBeatCount / 4) / 4 + "   " +totalBeatCount / 4 % 4 + "   " + totalBeatCount % 4+ "";

            // 亂寫一下
            if (totalBeatCount % 8 == 0)
            {
                Instantiate(laser);
            }

            // 用parse拆開資料然後傳給一個函式?

            // 本體觸發時間
        }

        
    }

    public void CreateLaser(int beatcount, int earlyWarning)
    {


    }
}
