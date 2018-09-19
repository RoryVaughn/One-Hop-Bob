using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {


    public GameObject platform;
    public float Movespeed;
    public Vector3 currentpos;
    public Transform[] points;
    public bool touched;
    public int target;
    public float platx;
    public float platy;
    public float platz;

    public float platDir;


    public static bool Frozen;
    public static bool freezeActive;
    public float freezeDelay;

    void OnCollisionEnter2D(Collision2D c)
    {
        //this allows the player to comtinue to move on the platform when he lands on it.
        c.collider.transform.SetParent(transform);
        
    }

    void OnCollisionExit2D(Collision2D c)
    {
        c.collider.transform.SetParent(null);
    
    }
    // Use this for initialization
    void Start () {
        bool touched = false;
        platDir = 1;
    }
    
    // Update is called once per frame
    void Update () {

        if (!Frozen)
        {
            
            //IMPORTANT - i need to find a way to do this for all variables of the platoforms position effieciently
            platx = Mathf.MoveTowards(platform.transform.position.x, points[target].position.x, Time.deltaTime * Movespeed);
            if ((platform.transform.position.x - points[target].position.x) > 0)
            {
                platDir = -platDir;
            }

            platy = Mathf.MoveTowards(platform.transform.position.y, points[target].position.y, Time.deltaTime * Movespeed);
            platz = Mathf.MoveTowards(platform.transform.position.z, points[target].position.z, Time.deltaTime * Movespeed);
            currentpos = new Vector3(platx, platy, platz);
        }

        platform.transform.position = currentpos;
        
        if (platform.transform.position == points[target].position)
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
