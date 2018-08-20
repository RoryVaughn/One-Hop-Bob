using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour {

    [SerializeField]
    private GameObject Player;
    private GameObject scoreBoard;

    public int power;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == Player)
        {
            takedamage();
        }
    }

    public void takedamage()
    {
        ScoreScript.health -= power;
        scoreBoard.GetComponent<ScoreScript>().healthCheck();
        Debug.Log("work");
    }

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        scoreBoard = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
