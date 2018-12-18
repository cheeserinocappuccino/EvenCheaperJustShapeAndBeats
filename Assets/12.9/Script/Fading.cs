using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    LineRenderer line;
    public float fadeOutSpeed;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        fadeOutSpeed += Time.deltaTime;
        Color m_color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(0f, 0f, 0f, 0f), fadeOutSpeed);
        Debug.Log(m_color);
        line.materials[0].SetColor("_TintColor", m_color);
        line.materials[1].SetColor("_TintColor", m_color);
        line.materials[2].SetColor("_TintColor", m_color);
    }
}
