using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFlash : MonoBehaviour {


    public int iftouched;
    private Color alphaColor;
    public float nowTime;
    public float timeToDie;
    public float fadespeed;
    
    private GameObject itSelf;

    public Vector3 nextFloorGeneratePos;

    private GameObject theDJ;
    private DJ theDjscript;

    private bool dontDoTwice;
	void Awake () {
        iftouched = 0;
        itSelf = this.gameObject;
        alphaColor = itSelf.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
        nowTime = 0;

        dontDoTwice = false;
        theDJ = GameObject.FindGameObjectWithTag("DJ");
        theDjscript = theDJ.GetComponent<DJ>();
        
	}

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime >= timeToDie && iftouched == 0)
        {
            
            theDjscript.nowTargetFloor = null;
            Destroy(transform.parent.gameObject);
            Destroy(itSelf);

        }
        else  if(iftouched == 1 && dontDoTwice == false)
        {
            itSelf.GetComponent<MeshRenderer>().material.color = new Color(itSelf.GetComponent<MeshRenderer>().material.color.r,
                itSelf.GetComponent<MeshRenderer>().material.color.g,
                itSelf.GetComponent<MeshRenderer>().material.color.b,
                1);
            dontDoTwice = true;
            
            
                }
        if (dontDoTwice == false)
        {
            itSelf.GetComponent<MeshRenderer>().material.color = Color.Lerp(itSelf.GetComponent<MeshRenderer>().material.color, alphaColor, fadespeed * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            iftouched  = 1;

           //nextFloorGeneratePos = new Vector3(transform.position.x,transform.position.y - 8, transform.position.z);
            theDjscript.theLastFloor = this.gameObject;
        }
        


    }
}
