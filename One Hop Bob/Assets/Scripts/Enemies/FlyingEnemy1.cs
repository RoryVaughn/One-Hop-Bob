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
    public float Timer;


    private GameObject Parent;
    private bool targetFound;
    private bool floatMode;
    private float hover;
    private bool Launch;
    private bool Lock;

    [SerializeField]
    private float MoveSpeed = 3;

   
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == Player)
        {
            targetFound = true;
        }

    }
    private void Awake()
    {
        targetFound = false;
    }
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
        currentpos = transform.position;
        Parent = gameObject.transform.parent.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        if (!Frozen)
        {
            if (targetFound == true)
            {

                    points[1] = Player.transform;

                if (floatMode == true && Launch == false && Lock == true)
                {

                    //IMPORTANT - i need to find a way to do this for all variables of the platoforms position effieciently
                    platy = Mathf.MoveTowards(transform.position.y, points[target].position.y, Time.deltaTime * MoveSpeed);
                    platz = Mathf.MoveTowards(transform.position.z, points[target].position.z, Time.deltaTime * MoveSpeed);
                }
                else
                {

                    //IMPORTANT - i need to find a way to do this for all variables of the platoforms position effieciently
                    platx = Mathf.MoveTowards(transform.position.x, points[target].position.x, Time.deltaTime * MoveSpeed);
                    platy = Mathf.MoveTowards(transform.position.y, points[target].position.y, Time.deltaTime * MoveSpeed);
                    platz = Mathf.MoveTowards(transform.position.z, points[target].position.z, Time.deltaTime * MoveSpeed);
                }

                if (Timer >= 1.5f)
                {
                    Lock = true;
                }
                if (Timer >= 4.5f)
                {
                    Launch = true;
                    target = 2;
                    MoveSpeed = 5f;
                }
                if (Timer >= 10f)
                {
                    Destroy(Parent);
                }

                Timer += Time.fixedDeltaTime;



                currentpos = new Vector3(platx, platy, platz);
            }


            transform.position = currentpos;

            if (transform.position == points[target].position)
            {
                target++;
                if (target == 1)
                {
                    floatMode = true;
                }
                else
                {
                    floatMode = false;
                }
                if (target >= points.Length)
                {
                    target = 0;
                }
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

