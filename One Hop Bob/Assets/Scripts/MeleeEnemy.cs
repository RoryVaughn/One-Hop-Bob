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
    

    private Collider2D frontCheck;


    public float platx;
    public float platy;
    public float platz;

    public static bool Frozen;
    public static bool freezeActive;
    public float freezeDelay;
    private Func<ContactFilter2D, Collider2D[], int> nullChecker;

    // Use this for initialization
    void Start () {
        Frozen = false;
        col = gameObject.GetComponent<BoxCollider2D>();
        frontCheck = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
        movementDirection = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (!Frozen)
        {
            nullChecker = frontCheck.GetComponent<BoxCollider2D>().OverlapCollider;
            if (nullChecker == null)
            {
                //if (gameObject.transform.forward == new Vector3(0,1, 0))
                //{
                transform.forward = -transform.forward;
                movementDirection = -movementDirection;
                    Debug.Log("work1");
                //}
                //else{
                //    transform.Rotate(new Vector3(0, -180, 0));
                //    Debug.Log("work2");
               //}
               
            }
            nullChecker = null;

            
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
