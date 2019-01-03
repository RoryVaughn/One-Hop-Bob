using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {



    public static int scoreValue = -1;
    public Text score;
    public GameObject Player;
    public GameObject[] HealthBar;
    private Slider Bar;
    private GameObject RedText;
    private bool Death;

    public static float health = 3.0f;

    public void GameOver()
    {
        Time.timeScale = (0.3f);
        Death = true;
        Player.GetComponentInChildren<Animator>().SetBool("Death", Death);
        RedText.active = true;
    }


    public void healthCheck()
    {

        switch ((int)health)
        {

            case 3: HealthBar[2].active = true;
                HealthBar[1].active = false;
                HealthBar[0].active = false;
                break;
            case 2:
                HealthBar[2].active = false;
                HealthBar[1].active = true;
                HealthBar[0].active = false;
                break;
            case 1:
                HealthBar[2].active = false;
                HealthBar[1].active = false;
                HealthBar[0].active = true;
                break;
            default:
                HealthBar[2].active = false;
                HealthBar[1].active = false;
                HealthBar[0].active = false;
                GameOver();
                break;
        }
    }
	// Use this for initialization
	void Start () {

        Player = GameObject.FindWithTag("Player");
        score = GameObject.Find("Score Text").GetComponent<Text>();
        RedText = GameObject.Find("RedText").GetComponent<GameObject>();
        health = 3.0f;

        healthCheck();

	}
    
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + scoreValue;
        
	}
}
