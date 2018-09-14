using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    public float movementSpeed;
    float movementDirection;
    private GameObject Player;
    BoxCollider2D col;
    public Vector3 currentpos;

    private GameObject frontCheck;


    public float platx;
    public float platy;
    public float platz;

    public static bool Frozen;
    public static bool freezeActive;
    public float freezeDelay;

   

    // Use this for initialization
    void Start () {
        Frozen = false;
        col = gameObject.GetComponent<BoxCollider2D>();
        frontCheck = transform.GetChild(0).gameObject;
        movementDirection = 2;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Frozen);
        if (!Frozen)
        {

            if (frontCheck.GetComponent<Wander>().nullCheck == false)
            {
                //if (gameObject.transform.forward == new Vector3(0,1, 0))
                //{
                transform.forward = -transform.forward;
                movementDirection = -movementDirection;
                Debug.Log(frontCheck.GetComponent<Wander>().nullCheck);
                //}
                //else{
                //    transform.Rotate(new Vector3(0, -180, 0));
                //    Debug.Log("work2");
               //}
               
            }


            
            //IMPORTANT - i need to find a way to do this for all variables of the platforms position effieciently
            platx = Mathf.MoveTowards(transform.position.x, transform.position.x + movementDirection,  Time.deltaTime * movementSpeed);
            platy = Mathf.MoveTowards(transform.position.y, transform.position.y, Time.deltaTime * movementSpeed);
            platz = Mathf.MoveTowards(transform.position.z, transform.position.z, Time.deltaTime * movementSpeed);
            currentpos = new Vector3(platx, platy, platz);
        }

        transform.position = currentpos;
        if (freezeDelay >= 7.5f)
        {
            freezeActive = false;
        }
        if (freezeActive)
        {
            Frozen = true;
            freezeDelay += Time.fixedDeltaTime;
        }
        else
        {
            Frozen = false;
            freezeDelay = 0;
        }
    }
}
