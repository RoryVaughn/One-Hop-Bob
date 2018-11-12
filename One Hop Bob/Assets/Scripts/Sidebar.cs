﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidebar : MonoBehaviour {


    float PercentComplete;
    float avatarYvalue;
    public Camera mainCam;
    public float levelHeight;
    float levelStart;
    GameObject Player;
    public Transform[] range;




	// Use this for initialization
	void Start () {

        Player = GameObject.Find("1HopBob");
        levelStart = Player.transform.position.y;
        gameObject.transform.position = range[1].transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        PercentComplete = ((Player.transform.position.y / levelHeight)) * 100;

        //IMPORTANT
        //the 4s in this calculation is so account for the starting spot of the camera that doesn not get accounted for. so a ratio of that missing 4
        //is gradually added along with the percentage complete ratios (using that same ratio).
        //the 7.5 is because the bottom value is -7.5 and the top value is 11.3 so i evens everything out. and the distance between those two numbers is the 18.8.

        avatarYvalue = (18.8f * PercentComplete/100)  + (4f * PercentComplete/100) - 7.5f + mainCam.transform.position.y - 4;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, avatarYvalue, gameObject.transform.position.z);

    }
}
