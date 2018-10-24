using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatedPlatform : MonoBehaviour {

    public float timeLimit;
    public float currentTimer;

    PlatformMove move;
	// Use this for initialization
	void Start () {
        move = gameObject.GetComponent<PlatformMove>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
