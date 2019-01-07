using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherCircleLaserBeha : MonoBehaviour {

    public Transform center;
    private LineRenderer lineRenderer;

   
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.0f;
 
       
	}
	
	
	void Update () {
        if (GetComponentInParent<TeacherCircleCenter>().activate == true)
        {
            if (lineRenderer.startWidth < 1)
            {
                lineRenderer.startWidth += Time.deltaTime * 2;
            }
            lineRenderer.SetPosition(0, center.position);



            lineRenderer.SetPosition(1, transform.position);
        }
        else
        {
            if (lineRenderer.startWidth > 0)
            {
                lineRenderer.startWidth -= Time.deltaTime * 3;
            }

            lineRenderer.SetPosition(0, center.position);



            lineRenderer.SetPosition(1, transform.position);
        }
	}
}
