using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour {

    private HoldData theScoreData;
    public Text gotHitText, floorForwardText, endScoreText;
    private int totalGothitScore, totalFloorForwardScore, totalEndScore;

    private int gothitScore, floorForwardScore, endScore;

    private int addingState;

    private bool hitCounted, floorCounted, totalCounted; // 讓他執行一次就好

    // 生成副標題
    public GameObject floorSubtitle, gotHitSubtitle,endSubtitle;

    public GameObject beepSound;
    private AudioSource beepSoundAudio;
    public AudioClip beepAudioClip;
    void Start () {
        beepSoundAudio =beepSound.GetComponent<AudioSource>();
        
        theScoreData = GameObject.FindGameObjectWithTag("GameController").GetComponent<HoldData>();
        totalGothitScore = HoldData.gotHitTimes;
        totalFloorForwardScore = HoldData.floorCount;

        addingState = 0;

        // 正在加的分數
        gothitScore = 0;
        floorForwardScore = 0;
        endScore = 0;

        hitCounted = false;
        floorCounted = false;
        totalCounted = false;

    }
	
	// Update is called once per frame
	void Update () {
        gotHitText.text = gothitScore.ToString();
        floorForwardText.text = floorForwardScore.ToString();
        endScoreText.text = endScore.ToString();
        if (addingState == 0 && floorCounted == false)
        {
            floorCounted = true;
            StartCoroutine(IEAddScore(totalFloorForwardScore, addingState));
        }
        else if (addingState == 1 && hitCounted == false)
        {
            hitCounted = true;
            StartCoroutine(IEAddScore(totalGothitScore, addingState));
        }
        else if (addingState == 2 && totalCounted == false)
        {
            totalCounted = true;
            StartCoroutine(IEAddScore(totalFloorForwardScore - totalGothitScore, addingState));


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            addingState += 1;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}


    // state是計分的三個階段
    IEnumerator IEAddScore( int _targetScore, int state)
    {
        if (addingState == 0)
        {
            while (_targetScore - floorForwardScore >= 15) // 如果還很多就不減慢
            {
                beepSoundAudio.PlayOneShot(beepAudioClip);
                

                floorForwardScore += 1;
                yield return new WaitForSeconds(0.02f);


            }
            while (_targetScore - floorForwardScore >= 10) // 第一次減慢
            {

                beepSoundAudio.PlayOneShot(beepAudioClip);
                floorForwardScore += 1;
                yield return new WaitForSeconds(0.15f);


            }
            while (_targetScore - floorForwardScore >= 5) // 第2次減慢
            {
                beepSoundAudio.PlayOneShot(beepAudioClip);

                floorForwardScore += 1;
                yield return new WaitForSeconds(0.25f);


            }
            while ((_targetScore - floorForwardScore > 0))
            {
                beepSoundAudio.PlayOneShot(beepAudioClip);

                floorForwardScore += 1;
                while (_targetScore - floorForwardScore == 0)
                {
                    _targetScore = -99999;
                    if (addingState == 0)
                    {
                        Instantiate(floorSubtitle);
                    }
                    yield return null;
                }
                yield return new WaitForSeconds(0.7f);

            }

        }
        else if (addingState == 1)
        {


            for (int i = 100; i > 0; i--)
            {
                /*
                gotHitText.transform.parent.GetComponent<RectTransform>().anchoredPosition -= new Vector2(10, 0);
                floorForwardText.rectTransform.position -= new Vector3(10, 0, 0);
                endScoreText.rectTransform.position -= new Vector3(10, 0, 0);*/


                gotHitText.rectTransform.anchoredPosition -= new Vector2(10, 0);
                floorForwardText.rectTransform.anchoredPosition -= new Vector2(10, 0);
                endScoreText.rectTransform.anchoredPosition -= new Vector2(10, 0);
                try
                {
                    GameObject.FindGameObjectWithTag("FloorSubtitle").GetComponentInChildren<Animator>().SetTrigger("Getout");
                }
                catch { }

                Debug.Log("WWWWWW");
                yield return null;

            }
            yield return new WaitForSeconds(1.0f);

            while (_targetScore - gothitScore >= 15) // 如果還很多就不減慢
            {

                beepSoundAudio.PlayOneShot(beepAudioClip);
                gothitScore += 1;
                yield return new WaitForSeconds(0.02f);


            }
            while (_targetScore - gothitScore >= 10) // 第一次減慢
            {

                beepSoundAudio.PlayOneShot(beepAudioClip);
                gothitScore += 1;
                yield return new WaitForSeconds(0.15f);


            }
            while (_targetScore - gothitScore >= 5) // 第2次減慢
            {
                beepSoundAudio.PlayOneShot(beepAudioClip);

                gothitScore += 1;
                yield return new WaitForSeconds(0.25f);


            }
            while ((_targetScore - gothitScore > 0))
            {
                beepSoundAudio.PlayOneShot(beepAudioClip);

                gothitScore += 1;
                while (_targetScore - gothitScore == 0)
                {
                    _targetScore = -99999;
                    if (addingState == 1)
                    {
                        Instantiate(gotHitSubtitle);
                    }
                    yield return new WaitForSeconds(0.5f);
                    
                }
      
                yield return new WaitForSeconds(0.7f);

            }

        }
        else if (addingState == 2)
        {
            for (int i = 100; i > 0; i--)
            {
                /*
                gotHitText.transform.parent.GetComponent<RectTransform>().anchoredPosition -= new Vector2(10, 0);
                floorForwardText.rectTransform.position -= new Vector3(10, 0, 0);
                endScoreText.rectTransform.position -= new Vector3(10, 0, 0);*/


                gotHitText.rectTransform.anchoredPosition -= new Vector2(10, 0);
                floorForwardText.rectTransform.anchoredPosition -= new Vector2(10, 0);
                endScoreText.rectTransform.anchoredPosition -= new Vector2(10, 0);
                try
                {
                    GameObject.FindGameObjectWithTag("FloorSubtitle").GetComponentInChildren<Animator>().SetTrigger("Getout");
                    GameObject.FindGameObjectWithTag("GotHitSubtitle").GetComponentInChildren<Animator>().SetTrigger("Getout");
                }
                catch { }
                
                Debug.Log("WWWWWW");
                yield return null;

            }

            // 最終分數
            while (_targetScore - endScore>= 15) // 如果還很多就不減慢
            {
                beepSoundAudio.PlayOneShot(beepAudioClip);

                endScore += 1;
                yield return new WaitForSeconds(0.02f);


            }
            while (_targetScore - endScore >= 10) // 第一次減慢
            {

                beepSoundAudio.PlayOneShot(beepAudioClip);
                endScore += 1;
                yield return new WaitForSeconds(0.15f);


            }
            while (_targetScore - endScore >= 5) // 第2次減慢
            {

                beepSoundAudio.PlayOneShot(beepAudioClip);
                endScore += 1;
                yield return new WaitForSeconds(0.25f);


            }
            while ((_targetScore - endScore > 0))
            {

                beepSoundAudio.PlayOneShot(beepAudioClip);
                endScore += 1;
                while (_targetScore - endScore == 0)
                {
                    _targetScore = -99999;
                    if (addingState == 2)
                    {
                        Instantiate(endSubtitle);
                    }
                    yield return new WaitForSeconds(0.5f);

                }

                yield return new WaitForSeconds(0.7f);

            }
        }
    }
}
