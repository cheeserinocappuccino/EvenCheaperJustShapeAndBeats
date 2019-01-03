using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
	void Start () {
        /*
        foreach (Songs song in songList)
        {
            song.theSongArtPicture.transform.position = new Vector3();

        }*/

        for (int i = 0; i < songList.Count; i++)
        {
            songList[i].tartgetPos = new Vector3(2 * i, 0, 2 * i);

        }
            changeArtPos();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U))
        {

            if (nowSelect < songList.Count-1)
            {
                nowSelect += 1;
                for (int i = nowSelect; i > 0; i--)     // 該移出畫面的先移出畫面
                {
                    songList[i - 1].tartgetPos += new Vector3(-4 , 0, -4 );

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
        
        else if (Input.GetKeyDown(KeyCode.Y))
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
                for (int i = nowSelect+1; i < songList.Count; i++)    
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IntoSong(songList[nowSelect].sceneNum);


        }
        changeArtPos();
    }

    public void changeArtPos()
    {
        for (int i = 0; i < songList.Count; i++)
        {
            //songList[i].tartgetPos = new Vector3(2 * i , 0, 2 * i);

 


            //songList[nowSelect - i].tartgetPos = new Vector3(-3 * (nowSelect - i), 0, -4 * (nowSelect - i));
            
            
            
            
            songList[i].theSongArtPicture.transform.position +=  (songList[i].tartgetPos - songList[i].theSongArtPicture.transform.position) / 10;


        }
    }

    public void IntoSong(int _sceneNum)
    {
        if (_sceneNum < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_sceneNum);
        }

    }
}
