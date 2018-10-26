using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehave : MonoBehaviour {
    public int healthPoint ;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (healthPoint <= 0)
        {
            Debug.Log("玩家扣血");
            Destroy(this.gameObject);
        }
	}

    public void Damaged(int amount)
    {
        healthPoint -= amount;

    }
}
