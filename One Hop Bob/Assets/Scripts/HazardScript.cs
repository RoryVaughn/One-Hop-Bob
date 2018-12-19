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
    public AudioSource hitSound;
    public bool winTrigger;



    public int power;

    public void OnTriggerEnter2D(Collider2D c)
    {
       
        //Collider[] colliders = Physics.OverlapSphere(explosionPos);

        if (c.gameObject == Player)
        {
            hitSound.Play();
            if (winTrigger)
            {
                scoreBoard.GetComponent<PauseMenu>().LevelComplete();
            }
            //The following math is to deturmine the directional vector that the knockback should be added to.
            float Linex = c.transform.position.x - transform.position.x;
            float Liney = c.transform.position.y - transform.position.y;
            Vector2 vector = new Vector2(Linex,Liney);
            float mag = Mathf.Sqrt((Linex * Linex) + (Liney * Liney));
            Vector2 Normalized = new Vector2(vector.x / mag, vector.y / mag);


            //https://www.youtube.com/watch?v=sdGeGQPPW7E
            Vector2 savedVelocity = Player.GetComponent<Playermove>().rb.velocity;
            c.gameObject.GetComponent<Playermove>().rb.velocity = new Vector2(0, 0);
            c.gameObject.GetComponent<Playermove>().rb.AddForceAtPosition(savedVelocity * -2.5f, c.transform.position, ForceMode2D.Impulse);
            c.gameObject.GetComponent<Playermove>().rb.AddForceAtPosition(Normalized * 3, c.transform.position, ForceMode2D.Impulse);
            c.gameObject.GetComponent<Playermove>().Invincibility = true;


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
