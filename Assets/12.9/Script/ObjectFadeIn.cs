using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeIn : MonoBehaviour {
    private MeshRenderer myMeshRenderer;
    private Color alphaColor;

    public float startAlpha = 0.0f;
    public float maxAlpha ;
    public float fadeInspeed = 2.0f;
  

	void Awake () {
        myMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        alphaColor.a = startAlpha;

            myMeshRenderer.material.color = new Color(
            myMeshRenderer.material.color.r,
            myMeshRenderer.material.color.g,
            myMeshRenderer.material.color.b,
            alphaColor.a
    );

    }
	
	// Update is called once per frame
	void Update () {
        alphaColor.a = Mathf.Lerp(alphaColor.a, maxAlpha, fadeInspeed * Time.deltaTime);
        myMeshRenderer.material.color = new Color(
            myMeshRenderer.material.color.r,
            myMeshRenderer.material.color.g,
            myMeshRenderer.material.color.b,
            alphaColor.a
            );
    }
}
