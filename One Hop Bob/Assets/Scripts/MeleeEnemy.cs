using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    public float movementSpeed;
    private GameObject Player;
    Collider2D col;
    public Vector3 currentpos;

    private Collider2D leftCheck;
    private Collider2D rightCheck;

    public float platx;
    public float platy;
    public float platz;

    public static bool Frozen;
    public static bool freezeActive;
    public float freezeDelay;

    // Use this for initialization
    void Start () {
        col = gameObject.GetComponent<Collider2D>();
        leftCheck = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
        rightCheck = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!Frozen)
        {
            //IMPORTANT - i need to find a way to do this for all variables of the platoforms position effieciently
            platx = Mathf.MoveTowards(transform.position.x, transform.position.x, Time.deltaTime * movementSpeed);
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
