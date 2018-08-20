using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    Vector2 position;
    Sprite health;
    Sprite doubleJump;
    Sprite Fireball;
    Sprite Freeze;
    Sprite Speed;
    Sprite Shield;
    Sprite Bow;
    private float speed = 6;
    public bool fly = true;
    public float Delay;
    public GameObject Owner;
    public int powerNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "1HopBob")
        {
            Owner = collision.gameObject;

            Destroy(this.gameObject);

        }

    }


    // Use this for initialization
    void Start () {
        switch(powerNum)
        {
            case 0:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite 
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
            position.y += Time.deltaTime * speed;
        if (fly == false)
            position.y -= Time.deltaTime * speed;
        transform.position = new Vector3(position.x, position.y);
    
	}
}
