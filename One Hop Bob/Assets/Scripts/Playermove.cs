using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {

    public GameObject Player;
    public float highjumpPower;
    public float fallMultiplier;
    public Rigidbody2D rb;
    public bool grounded;
    public List<Collider2D> groundtouched = new List<Collider2D>();



    void OnCollisionEnter2D(Collision2D c)
    {
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
        if (groundtouched.Contains(c.collider))
        {
            groundtouched.Remove(c.collider);
        }
    }


    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        if (groundtouched.Count != 0)
        {
            grounded = true;
        }
        else grounded = false;
        if (rb.velocity.y < 0)
        {
            rb.velocity += (Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += (Vector2.up * Physics2D.gravity.y * (highjumpPower - 1) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {

            rb.AddForce(Vector2.up * highjumpPower, ForceMode2D.Impulse);

        }
    }


}
