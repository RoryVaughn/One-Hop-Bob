using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;
    private GameObject scoreBoard;
    public bool isProjectile;
    private float moveSpeed;
    private float newX;
    private float newY;
    public AudioSource hitSound;
    public bool winTrigger;
    public int knockbackCount;
    public int knockbackForce;
    public bool floorDeath;
    public bool OnlyYKnock;



    public int power;

    public void OnTriggerEnter2D(Collider2D c)
    {

       

        if (c.gameObject == Player)
        {
            hitSound.Play();
            if (winTrigger)
            {
                scoreBoard.GetComponent<PauseMenu>().LevelComplete();
            }
            if (c.GetComponent<Playermove>().knockbackCount < 1 || gameObject.GetComponent<HazardScript>().floorDeath)
            {
                c.GetComponent<Playermove>().Controls = false;
                c.GetComponent<Playermove>().knockbackCount++;
                //The following math is to deturmine the directional vector that the knockback should be added to.
                float knockX;
                float knockY;
                if (OnlyYKnock == true)
                {
                    knockX = gameObject.GetComponent<Rigidbody2D>().position.x / 2;
                    if (c.transform.position.y > gameObject.transform.position.y)
                    {
                        knockY = 1f;
                    }
                    else
                    {
                        knockY = -1f;
                    }
                }
                else
                {
                    knockX = gameObject.GetComponent<Rigidbody2D>().position.x;
                    knockY = gameObject.GetComponent<Rigidbody2D>().position.y;
                }
                float Linex = c.gameObject.GetComponent<Playermove>().rb.position.x - knockX;
                float Liney = c.gameObject.GetComponent<Playermove>().rb.position.y - knockY;
                Vector2 vector = new Vector2(Linex, Liney);
                float mag = Mathf.Sqrt((Linex * Linex) + (Liney * Liney));
                Vector2 Normalized = new Vector2(vector.x / mag, vector.y / mag);
 


                //Vector2 savedVelocity = Player.GetComponent<Playermove>().rb.velocity;
                //c.gameObject.GetComponent<Playermove>().rb.velocity = new Vector2(0, 0);
                //c.gameObject.GetComponent<Playermove>().rb.AddForceAtPosition(savedVelocity * -2.5f, c.gameObject.GetComponent<Playermove>().rb.position, ForceMode2D.Impulse);
                c.gameObject.GetComponent<Playermove>().rb.AddForceAtPosition(Normalized * knockbackForce, c.transform.position, ForceMode2D.Impulse);
            }


            if (!c.gameObject.GetComponent<Playermove>().Invincibility)
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
    }

    IEnumerator WaitSeconds(int x)
    {
        yield return new WaitForSeconds(x);
    }

    public void takedamage()
    {
        ScoreScript.health -= power;
        scoreBoard.GetComponent<ScoreScript>().healthCheck();
        if (ScoreScript.health > 0)
        {
            Player.GetComponent<Playermove>().Invincibility = true;
        }
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
