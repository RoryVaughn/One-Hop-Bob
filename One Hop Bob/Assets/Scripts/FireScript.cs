using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public GameObject Player;
    [SerializeField]
    private GameObject scoreBoard;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == Player)
        {
            takedamage();

        }
    }

    void takedamage()
    {
        scoreBoard.GetComponent<ScoreScript>().health--;
        scoreBoard.GetComponent<ScoreScript>().healthCheck();
        Debug.Log("work");
    }

    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
        scoreBoard = GameObject.Find("HUD");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
