using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    public float movementSpeed;
    private GameObject Player;
    Collider2D col;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == Player)
        {
            

        }
    }
	// Use this for initialization
	void Start () {
        col = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
