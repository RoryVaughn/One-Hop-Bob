using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy1 : MonoBehaviour {

    private GameObject Player;
    public static bool Frozen;
    public static bool freezeActive;
    public float freezeDelay;
    public Vector3 currentpos;
    public Transform[] points;
    public int target;
    public float platx;
    public float platy;
    public float platz;

    [SerializeField]
    private float MoveSpeed = 1;





    void OnTriggerEnter2D(Collision2D c)
    {
        if (c.gameObject == Player)
        {

        }

    }
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (!Frozen)
        {

            //IMPORTANT - i need to find a way to do this for all variables of the platoforms position effieciently
            platx = Mathf.MoveTowards(transform.position.x, points[target].position.x, Time.deltaTime * MoveSpeed);
            platy = Mathf.MoveTowards(transform.position.y, points[target].position.y, Time.deltaTime * MoveSpeed);
            platz = Mathf.MoveTowards(transform.position.z, points[target].position.z, Time.deltaTime * MoveSpeed);
            currentpos = new Vector3(platx, platy, platz);
        }

        transform.position = currentpos;

        if (transform.position == points[target].position)
        {
            target++;
            if (target >= points.Length)
            {
                target = 0;
            }
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

