using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public Sprite Background;
    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    public float groundVerticalLength;       //A float to store the y-axis length of the collider2D attached to the Ground GameObject.
    private GameObject Camera;
    public float offset = 17f;
    public bool lowerSection;

    //Awake is called before Start.
    private void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        groundCollider = GetComponent<BoxCollider2D>();
        Camera = GameObject.FindWithTag("MainCamera");
    }

    //Update runs once per frame
    private void Update()
    {
        //Check if the difference along the y axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (Camera.transform.GetChild(1).transform.position.y > transform.position.y + offset  )

        {
            Debug.Log("hello");
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.

            RepositionBackground();
        }
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        //This is how far to the up we will move our background object, in this case, twice its length. This will position it above the currently visible background object.
        Vector2 groundOffSet = new Vector2(0, groundVerticalLength);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera above of the player.
        if ((transform.position.y + groundOffSet.y <= 90f) || lowerSection)
        {
            transform.position = (Vector2)transform.position + new Vector2(groundOffSet.x, groundOffSet.y);
        }


    }
}