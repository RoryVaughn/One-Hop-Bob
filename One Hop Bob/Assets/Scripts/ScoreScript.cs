using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {



    public static int scoreValue = 0;
    public Text score;
    public GameObject Player;

    public int health;


	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score Text").GetComponent<Text>();
        health = 3;
	}
	
	// Update is called once per frame
	void Update () {
        scoreValue = (int) (Player.GetComponent<Transform>().position.y / 4.0f);
        score.text = "Score: " + scoreValue;
	}
}
