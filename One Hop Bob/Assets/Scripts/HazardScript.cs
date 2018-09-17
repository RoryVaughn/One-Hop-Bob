using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour {

    [SerializeField]
    private GameObject Player;
    private GameObject scoreBoard;
    public bool isProjectile;
    private float moveSpeed;
    private float newX;
    private float newY;

    public int power;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == Player)
        {
            if (!c.GetComponent<Playermove>().hasShield)
            {
                takedamage();
            }
            else 
            {
                c.GetComponent<Playermove>().hasShield = false;
                c.transform.GetChild(1).gameObject.SetActive(false);
            }

        }
    }

    public void takedamage()
    {
        ScoreScript.health -= power;
        scoreBoard.GetComponent<ScoreScript>().healthCheck();
        Debug.Log("work");
    }

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        scoreBoard = GameObject.Find("HUD");
        moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isProjectile)
        {
            newX = Mathf.MoveTowards(transform.position.x, transform.position.x + 1.0f, Time.deltaTime * moveSpeed);
            newY = Mathf.MoveTowards(transform.position.y, transform.position.y + 1.0f, Time.deltaTime * moveSpeed);
            gameObject.transform.position = new Vector2(newX, newY);
        }
    }
}
