using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public bool nullCheck;
    public bool firstHit;
    public GameObject parentPlat;


    void OnTriggerEnter2D(Collider2D other)
    {
        nullCheck = true;
        if (firstHit == false)
        {
            parentPlat = other.gameObject;
        }
        Debug.Log("in");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        nullCheck = false;
        Debug.Log("out");
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
