using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Animator anim;
    private float VerticalVelocity;
    private float HorizontalVelocity;
    private bool newFlag;
    private bool facingRight;
    private bool stopped;
    public AudioSource flagSound;
    public AudioSource jumpSound;
    


    //PowerUpstuff
    public bool boostActive;
    private float boostSpeed;
    public float boostDelay;

    public int jumpLeft;
    public bool doubleJump;
    public bool hasFireball;
    GameObject fireBall;
    public bool hasArrow;
    public bool hasShield;
    public AudioSource shieldSound;

    //DebugStuff
    public bool testingRespawnMode;





    void OnCollisionEnter2D(Collision2D c)
    {
        //adds objects that the player collides with to an array (only once) 
        //then signals that the player is grounded if the array is not empty
        //this allows the player to jump
        ContactPoint2D[] points = new ContactPoint2D[2];
        c.GetContacts(points);
        if (doubleJump)
        {
            jumpLeft = 2;
        }

        for (int i = 0; i < points.Length; i++)
        {

            if (points[i].normal == Vector2.up && !groundtouched.Contains(c.collider))
            {
                
                lastTouched = c.gameObject;
                groundtouched.Add(c.collider);
                if (!Achieved.Contains(c.gameObject))
                {
                    flagSound.Play();
                    // PLaces the flag where the player landed on the platform
                    float flagSide;
                    if (facingRight == true)
                    {
                        flagSide = 0.5f;
                    }
                    else
                    {
                        flagSide = -0.3f;
                    }
                    Vector3 newFlagSpot = new Vector3(transform.position.x + flagSide, transform.position.y, transform.position.z);
                    Instantiate(Flag, newFlagSpot, c.gameObject.transform.rotation,c.gameObject.transform);
                    newFlag = true;
                    anim.SetBool("newFlag", newFlag);
                    //adds platform to the list
                    Achieved.Add(c.gameObject);
                    ScoreScript.scoreValue++;

                }
                return;
            } 
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        newFlag = false;
        anim.SetBool("newFlag", newFlag);
        grounded = true;
    }
    void OnCollisionExit2D(Collision2D c)
    {
        //deletes the touched object as the player exits the collision to avoid double jumps
        if (groundtouched.Contains(c.collider))
        {
            jumpSound.Play();
            groundtouched.Remove(c.collider);
            newFlag = false;
            anim.SetBool("newFlag", newFlag);
            anim.SetBool("Grounded", grounded);
        }
    }
    // Flip function
    private void Flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
            {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;


             theScale.x *= -1;

            transform.localScale = theScale;
        }
    }




    // Use this for initialization
    void Start() {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Stopped", stopped);
        anim.SetFloat("VerticalVelocity", VerticalVelocity);
        anim.SetFloat("HorizontalVelocity", hMove);
        boostSpeed = 1;
        Respawn = transform.position;
        rb = GetComponent<Rigidbody2D>();
        fireBall = Resources.Load<GameObject>("FireBall");
        facingRight = true;



    }

    // Update is called once per frame
    void Update() {

        
        //Horzontal walking input
        hMove = Input.GetAxis("Horizontal");

        anim.SetFloat("HorizontalVelocity", Mathf.Abs(hMove));
        if (hMove == 0)
        {
            stopped = true;
        }
        else
        {
            stopped = false;
        }
        anim.SetBool("Stopped", stopped);


        //this is the current method of movement
        transform.position += new Vector3(hMove,0,0) * boostSpeed * walkspeed * Time.deltaTime;
        Flip(hMove);
        //The following check is to make the player unable to jump twice without grounding first
        if (groundtouched.Count != 0)
        {
            grounded = true;
            anim.SetBool("Grounded", grounded);
        }
        else grounded = false;
        anim.SetBool("Grounded", grounded);
        //This allows the player to achievea higher jump by holding the jump button for longer.

        if (rb.velocity.y < 0)
        {
            rb.velocity += (Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += (Vector2.up * Physics2D.gravity.y * (highJumpPower - 1) * Time.deltaTime);
        }
        VerticalVelocity = rb.velocity.y;
        anim.SetFloat("VerticalVelocity", VerticalVelocity);
        //Jump Input
        if ((Input.GetKeyDown(KeyCode.Space) && grounded == true) || (Input.GetKeyDown(KeyCode.Space) && jumpLeft > 0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * highJumpPower, ForceMode2D.Impulse);
            jumpLeft--;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            SceneManager.LoadScene(1);
            ScoreScript.scoreValue = -1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }



        //////////////////////////////////////////////////
        //// BELOW THIS POINT IS POWER UP INFORMATION ////
        //////////////////////////////////////////////////

        //Speed Boost
        if (boostActive)
        {
            Boost();
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
