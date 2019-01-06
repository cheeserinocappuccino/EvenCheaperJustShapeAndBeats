using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Shake(float duration, float magnitude)
    {
        //Vector3 originalPos = transform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position += new Vector3(x, y, 0);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 15), transform.position.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;

        }

        //transform.position = new Vector3(originalPos.x,transform.position.z,transform.position.z);
    }
}
