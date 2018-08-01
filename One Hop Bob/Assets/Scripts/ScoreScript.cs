using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {



    public static int scoreValue = 0;
    private Text score;
    public GameObject Player;
    private Slider Bar;

    public int health;

    public void healthCheck()
    {
        Bar.value = health;
    }
	// Use this for initialization
	void Start () {
        Bar = GameObject.Find("Health").GetComponent<Slider>();
        score = GameObject.Find("Score Text").GetComponent<Text>();
        health = 3;
        Bar.value = health;
	}
	
	// Update is called once per frame
	void Update () {
        scoreValue = (int) (Player.GetComponent<Transform>().position.y / 4.0f);
        score.text = "Score: " + scoreValue;
	}
}
