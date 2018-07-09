using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {


    public GameObject platform;
    public int Movespeed;
    public Vector3 currentpos;
    public Transform[] points;
    public int target;
    public float platx;
    public float platy;
    public float platz;

    void OnCollisionEnter2D(Collision2D c)
    {
        c.collider.transform.SetParent(transform);
        
    }

    void OnCollisionExit2D(Collision2D c)
    {
        c.collider.transform.SetParent(null);
    
    }
    // Use this for initialization
    void Start () {
        platy = platform.transform.position.y;
        platz = platform.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        platx = Mathf.MoveTowards(platform.transform.position.x, points[target].position.x, Time.deltaTime * Movespeed);
        currentpos = new Vector3(platx,platy,platz);


        platform.transform.position = currentpos;
        
        if (platform.transform.position.x == points[target].position.x)
        {
            target++;
            if (target >= points.Length)
            {
                target = 0;
            }
        }


	}
}
