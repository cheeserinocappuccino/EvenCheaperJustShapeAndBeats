using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvasRenderColor : MonoBehaviour {

    private CanvasRenderer canvasRenderer;
    public Color changerTothisColorA, changerTothisColorB;
    private Color lerpingColor;
    private float a;
	void Start () {
        canvasRenderer = GetComponent<CanvasRenderer>();
        a = 0;
	}

    // Update is called once per frame
    void Update() {
        //a += Time.deltaTime;
        a = Mathf.PingPong(Time.time, 1.0f);
        lerpingColor = Color.Lerp(changerTothisColorA, changerTothisColorB, a); // 

        canvasRenderer.SetColor(lerpingColor);
    }
}
