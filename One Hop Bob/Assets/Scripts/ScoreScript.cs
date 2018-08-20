using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {



    public static int scoreValue = -1;
    public Text score;
    public GameObject Player;
    private Slider Bar;

    public static float health;

    public void healthCheck()
    {
        Bar.value = health;
    }
	// Use this for initialization
	void Start () {
        Bar = GameObject.Find("Health").GetComponent<Slider>();
        score = GameObject.Find("Score Text").GetComponent<Text>();
        health = 3.0f;

        Bar.value = health;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + scoreValue;
	}
}
