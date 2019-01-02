using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleCircle : MonoBehaviour {

    
    private float x, y;
    private RectTransform theRect;
	// Use this for initialization
	void Start () {
        x = 0;y = 0;
        
        
        theRect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (x < 1)
        {
            x += 1 / 0.6896544f * Time.deltaTime;
            
        }

        if (y < 1)
        {
            y += 1 / 0.6896544f * Time.deltaTime;
        }
        if (x >= 1 || y >= 1)
        {
            Destroy(gameObject);
            //Debug.Log(x);
        }

        
        theRect.transform.localScale = new Vector3(x, y, 0);

        // 在來寫一個讀簡單譜的程式 要跟notecount分開
    }
}
