using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {


    public Camera main;
    public GameObject player;

    public float DefaultscrollSpeed;
    public float CurrentscrollSpeed;
    float targetHeight;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("1HopBob");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<Playermove>().grounded)
        {
            targetHeight = (4 + player.GetComponent<Playermove>().lastTouched.transform.position.y);
        }

        if (targetHeight < main.GetComponent<Transform>().position.y)
        {
            //downward scroll speed
            CurrentscrollSpeed = 1;
        }
        else
        {
            //upward scroll speed
            CurrentscrollSpeed = DefaultscrollSpeed;
        }
        main.GetComponent<Transform>().position = Vector3.MoveTowards(main.GetComponent<Transform>().position, new Vector3(0, targetHeight, -10),CurrentscrollSpeed);

    }
}
