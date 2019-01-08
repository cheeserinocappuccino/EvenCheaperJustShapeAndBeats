using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankGetIn : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Color theColor;
    Color alphaColor;
    float alpha;
    public static bool isFadingIn;
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        theColor = spriteRenderer.material.color;
        alpha = 0.0f;
        alphaColor = new Color(theColor.r, theColor.g, theColor.b,alpha);
        isFadingIn = true;
    }
	
	// Update is called once per frame
	void Update () {
        alphaColor = new Color(theColor.r, theColor.g, theColor.b, alpha);

        theColor = alphaColor;

        if (alpha <= 1 && isFadingIn == true)
        {
            alpha += Time.deltaTime;
        }
        else if (alpha > 0 && isFadingIn == false)
        {
            alpha -= Time.deltaTime;
        }
    }
}
