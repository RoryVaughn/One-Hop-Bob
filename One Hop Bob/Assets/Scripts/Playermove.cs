using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {

    public GameObject Player;
    private Vector3 Respawn;
    public float highJumpPower;
    public float fallMultiplier;
    public float walkspeed;
    public Rigidbody2D rb;
    public bool grounded;
    public GameObject lastTouched;
    public List<Collider2D> groundtouched = new List<Collider2D>();
    public List <GameObject> Achieved = new List<GameObject>();
    float hMove;
    public GameObject Flag;


    //PowerUpstuff
    public bool boostActive;
    private float boostSpeed;
    public float boostDelay;

    public bool hasFireball;
    GameObject fireBall;
    public bool hasArrow;
    public bool hasShield;

    //DebugStuff
    public bool testingRespawnMode;





    void OnCollisionEnter2D(Collision2D c)
    {
        //adds objects that the player collides with to an array (only once) 
        //then signals that the player is grounded if the array is not empty
        //this allows the player to jump
        ContactPoint2D[] points = new ContactPoint2D[2];
        c.GetContacts(points);
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].normal == Vector2.up && !groundtouched.Contains(c.collider))
            {
                lastTouched = c.gameObject;
                groundtouched.Add(c.collider);
                if (!Achieved.Contains(c.gameObject))
                {
                    // PLaces the flag where the player landed on the platform
                    Vector3 newFlagSpot = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
                    Instantiate(Flag, newFlagSpot, c.gameObject.transform.rotation,c.gameObject.transform);

                    //adds platform to the list
                    Achieved.Add(c.gameObject);
                    ScoreScript.scoreValue++;

                }
                return;
            } 
        }
    }
    void OnCollisionExit2D(Collision2D c)
    {
        //deletes the touched object as the player exits the collision to avoid double jumps
        if (groundtouched.Contains(c.collider))
        {
            groundtouched.Remove(c.collider);
        }
    }


    // Use this for initialization
    void Start() {
        boostSpeed = 1;
        Respawn = transform.position;
        rb = GetComponent<Rigidbody2D>();
        fireBall = Resources.Load<GameObject>("FireBall");



    }

    // Update is called once per frame
    void Update() {

        //Horzontal walking input
        hMove = Input.GetAxis("Horizontal");

        //this is the current method of movement
        transform.position += new Vector3(hMove,0,0) * boostSpeed * walkspeed * Time.deltaTime;

        //The following check is to make the player unable to jump twice without grounding first
        if (groundtouched.Count != 0)
        {
            grounded = true;
        }
        else grounded = false;

        //This allows the player to achievea higher jump by holding the jump button for longer.

        if (rb.velocity.y < 0)
        {
            rb.velocity += (Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += (Vector2.up * Physics2D.gravity.y * (highJumpPower - 1) * Time.deltaTime);
        }
        //Jump Input
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.AddForce(Vector2.up * highJumpPower, ForceMode2D.Impulse);
        }

        //////////////////////////////////////////////////
        //// BELOW THIS POINT IS POWER UP INFORMATION ////
        //////////////////////////////////////////////////

        //Speed Boost
        if (boostActive)
        {
            Boost();
        }


        //Fireball and Arrow
        if (hasArrow)
        {

        }
        if (hasFireball)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fireBall = Instantiate(fireBall, new Vector3(transform.position.x + 2.0f, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);
            }
        }
        if (hasShield)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }

        /////////////////////////////////////////////////////////////////////////////////
        ////BELOW THIS POINT IS DEBUGGING CODE THAT SHOULD BE CHANGED WHEN BUILDING! ////
        /////////////////////////////////////////////////////////////////////////////////

        //Testing respawn check
        if (testingRespawnMode)
        {
            if (transform.position.y < -1.0f)
            {
                transform.position = Respawn;
            }
        }
    }


    public void Boost()
    {
            if (boostDelay >= 7.5f)
            {
                boostActive = false;
            }
            if (boostActive)
            {
                boostSpeed = 2.0f;
                boostDelay += Time.fixedDeltaTime;
            }
            else
            {
                boostSpeed = 1;
                boostDelay = 0;
            }
    }
}
