using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMinusing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerSmash playerSmash = other.GetComponent<PlayerSmash>();
            if (playerSmash.immortalTime < 0)
            {
                StartCoroutine(DealWithPlayer());
            }
        }
    }

    IEnumerator DealWithPlayer()
    {
        for(int i = 0; i < 1; i ++)
        {
            DJ theDj = GameObject.FindGameObjectWithTag("DJ").GetComponent<DJ>();
            theDj.ScoreChange(-1);
            PlayerSmash playerSm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSmash>();
            playerSm.playerGetHurt();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
