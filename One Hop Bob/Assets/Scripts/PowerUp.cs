using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {


    Sprite health;
    Sprite doubleJump;
    Sprite Fireball;
    Sprite Freeze;
    Sprite Speed;
    Sprite Shield;
    Sprite Bow;

    Vector2 pos;
    private GameObject scoreBoard;
    private GameObject Player;
    private float speed = 1;
    public bool fly = true;
    public float Delay;
    public GameObject Owner;
    public int powerNum;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "1HopBob")
        {
            Owner = collision.gameObject;

            switch (powerNum)
            {
                case 0:
                    {
                        ScoreScript.health++;
                        scoreBoard.GetComponent<ScoreScript>().healthCheck();
                    }
                    break;
                case 1:
                    {
                        Player.GetComponent<Playermove>().boostActive = true;

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;
                case 4:
                    {

                    }
                    break;
                case 5:
                    {

                    }
                    break;

            }
            Destroy(this.gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        scoreBoard = GameObject.Find("HUD");
        Player = GameObject.FindWithTag("Player");
        pos = transform.position;
        switch(powerNum)
        {
            case 0:
                {
                    //gameObject.GetComponent<SpriteRenderer>().sprite = Freeze;
                }
                break;
        }
	}


    // Update is called once per frame
    void Update()
    {
        
        Delay += Time.fixedDeltaTime;
        //the following block of code makes the powerups appear to float
        if (Delay >= 0.5f)
        {
            Delay = 0;
            fly = !fly;
        }
        if (fly == true)
            
            pos.y += Time.fixedDeltaTime * speed;
        if (fly == false)

            pos.y -= Time.fixedDeltaTime * speed;

        
        transform.position = new Vector2(transform.position.x, pos.y);
    
	}
}
