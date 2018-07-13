using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {

    public GameObject Player;
    public bool testingRespawnMode;
    private Vector3 Respawn;
    public float highJumpPower;
    public float fallMultiplier;
    public float walkspeed;
    public float maxSpeed;
    public Rigidbody2D rb;
    public bool grounded;
    public List<Collider2D> groundtouched = new List<Collider2D>();
    float hMove;



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
                groundtouched.Add(c.collider);
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

        Respawn = transform.position;
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update() {

        //Testing respawn check
        if (testingRespawnMode)
        {
            if (transform.position.y < -1.0f)
            {
                transform.position = Respawn;
            }
        }
        //Horzontal walking input
        hMove = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * walkspeed * hMove, ForceMode2D.Force);

        //This caps the maximum speed the player can achieve, to avoid infinitely building momentum
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed,rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
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
    }
}
