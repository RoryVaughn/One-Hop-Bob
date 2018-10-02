using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {


    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundVerticalLength;       //A float to store the y-axis length of the collider2D attached to the Ground GameObject.
    private GameObject Camera;

    //Awake is called before Start.
    private void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        groundCollider = GetComponent<BoxCollider2D>();
        //Store the size of the collider along the y axis (its length in units).
        groundVerticalLength = 36f;
        Camera = GameObject.FindWithTag("MainCamera");
    }

    //Update runs once per frame
    private void Update()
    {
        //Check if the difference along the y axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (Camera.transform.GetChild(1).transform.position.y > transform.position.y + 17f )

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
        transform.position = (Vector2)transform.position + new Vector2(groundOffSet.x, groundOffSet.y);
    }
}