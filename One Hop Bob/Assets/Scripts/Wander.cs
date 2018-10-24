using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public bool nullCheck;
    public bool firstHit;
    public GameObject parentPlat;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlatformMove>())
        {
            nullCheck = true;

            Debug.Log("in");
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlatformMove>())
        {
            nullCheck = false;
            Debug.Log("out");
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
