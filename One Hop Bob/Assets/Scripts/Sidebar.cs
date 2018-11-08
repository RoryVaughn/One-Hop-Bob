using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidebar : MonoBehaviour {


    float Yvalue;
    public float levelHeight;
    float levelStart;
    GameObject Player;


	// Use this for initialization
	void Start () {
        Player = GameObject.Find("1HopBob");
        levelStart = Player.transform.position.y;


    }
	
	// Update is called once per frame
	void Update () {
        Yvalue = ((Player.transform.position.y/ levelHeight)) * 100;
        Debug.Log(Yvalue);



	}
}
