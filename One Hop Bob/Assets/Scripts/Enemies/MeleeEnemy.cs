using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    public float movementSpeed;
    float movementDirection;
    float movementSpeedO;
    public float movementMultiplier = 0.6f;
    float slowMove;
    private GameObject Player;
    BoxCollider2D col;
    public Vector3 currentpos;

    private GameObject frontCheck;
    private GameObject parentPlat;


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

        movementSpeedO = 0.8f;
        slowMove = movementMultiplier;
        movementSpeed = movementSpeedO;
    }
	

	// Update is called once per frame
	void Update () {

        if (!Frozen)
        {

            if (frontCheck.GetComponent<Wander>().nullCheck == false)
            {
                //this code changes the direction of the enemy if it is about to fall off of a platform
                transform.forward = -transform.forward;
                movementDirection = -movementDirection;

                //this code checks the velocity to deturmine how fast the enemy should walk to avoid looking dumb when walking the same direction as the platfrom he is on,
                if (((GetComponentInParent<PlatformMove>().platDir > 0) && (movementDirection < 0)) || ((GetComponentInParent<PlatformMove>().platDir < 0) && (movementDirection > 0)))
                {
                    movementSpeed = slowMove;
                }
                else
                {
                    movementSpeed = movementSpeedO;

                }

            }

            transform.position += new Vector3(movementDirection, 0, 0) * movementSpeed * Time.deltaTime;
        }


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
