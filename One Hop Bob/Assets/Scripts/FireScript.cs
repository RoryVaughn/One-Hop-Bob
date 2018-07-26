using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public GameObject Player;
    private GameObject scoreBoard;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject == Player)
        {
            takedamage();
        }

    }
    void takedamage()
    {
        scoreBoard.gameObject.GetComponent<ScoreScript>().health--;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
