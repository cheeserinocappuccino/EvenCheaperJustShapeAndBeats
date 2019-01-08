using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGlow : MonoBehaviour {


    
    private int startBeatcount;
    public bool explode;
    public int earlySetExplode;  // 一律早2拍(8個count)把explode改成true
    private bool dontDoitTwice;
    private SpriteRenderer spriteRenderer;

    public GameObject theActualAttack;
    public GameObject thePlayer;
    private float a = 0;
    private void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        transform.position = thePlayer.transform.position;
        StartCoroutine(IEFadeIn());


    }
    void Start () {
        startBeatcount = DJ.totalBeatCount;
        explode = false;
        dontDoitTwice = false;

        
	}
	
	// Update is called once per frame
	void Update () {
        if (explode == true && dontDoitTwice == false)
        {
            startBeatcount = DJ.totalBeatCount;
            StartCoroutine(IESniperFlash());
            dontDoitTwice = true;
        }
        else if (explode == true)
        {
            if (DJ.totalBeatCount - startBeatcount == earlySetExplode)
            {
                Instantiate(theActualAttack,this.transform.position,this.transform.rotation);
                explode = false;
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            explode = true;

        }
	}

    IEnumerator IESniperFlash()
    {
        for (int i = 0; i < 50; i++)
        {
            if (spriteRenderer.color.g == 0)
            {
                spriteRenderer.color = new Color(255, 255, 255, 0.7f);
            }
            else if (spriteRenderer.color.g == 255)
            {
                spriteRenderer.color = new Color(255, 0, 0, 0.7f);
            }
            yield return new WaitForSeconds(0.06f);
        }
    }

    IEnumerator IEFadeIn()
    {
        while (spriteRenderer.color.a < 1)
        {
            a = Mathf.Lerp(a, 1, 1f * Time.deltaTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,a);
            yield return null;
        }
    }
}
