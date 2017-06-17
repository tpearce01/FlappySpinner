using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************
 * public class PlayerController
 * 
 * Purpose: Control all player functionalities. Functionalities
 *      include movement, collision, and death.
 *****************************************************************/
public class PlayerController : MonoBehaviour
{
    [SerializeField] private string _userID;                //User ID
    [SerializeField] private short _verticalVelocity;       //Vertical velocity value set on user input
    [SerializeField] private short _angularVelocity;        //Angular velocity increase on user input
    [SerializeField] private Rigidbody2D _rgbd;             //This gameobjects rigidbody
    [SerializeField] Vector2 _velocity;                     //Current velocity values
    [SerializeField] private int _gravityScale;             //Gravity scale effecting this object
    [SerializeField] private bool isTouchingBoundary;       //Determines if the object is resting on a boundary
    [SerializeField] private float startingPositionXScale;  //Determines the X starting position of the object
                                                            //  relative to screen width

	// Initialize player position based on screen size
	void Start ()
	{
        float unitWidth = (Screen.width / 2) / Camera.main.orthographicSize;
        gameObject.transform.position = new Vector2(-unitWidth * .033f, 0);
    }
	
	// Move the player on every frame
	void Update () {
		Move();
    }

    /// <summary>
    /// Check if the user wishes to perform a movement action
    /// </summary>
    bool GetInput()
    {
        if (Input.anyKeyDown)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Sets the placeholder velocity Y. Set to verticalVelocity if
    /// user input is received. Otherwise, decrement by gravity value
    /// </summary>
    void PrepareVerticalVelocity()
    {
         if (GetInput())
        {
            _velocity.y = _verticalVelocity;
        }
        else
        {
            _velocity.y -= _gravityScale * Time.deltaTime;
        }
    }

    /// <summary>
    /// Enact the velocity upon the rigidbody
    /// </summary>
    void SetFinalVelocity()
    {
        _rgbd.velocity = _velocity;
    }

    /// <summary>
    /// Perform all neccessary steps for moving the player
    /// </summary>
    void Move()
    {
        GetInput();
        PrepareVerticalVelocity();
        SetFinalVelocity();
        Rotate();
    }

    /// <summary>
    /// Increase the angular velocity if input is received
    /// </summary>
    void Rotate()
    {
        if (GetInput())
        {
            _rgbd.angularVelocity += _angularVelocity;
        }
    }

    /// <summary>
    /// Controls all functions and cleanup related to death. This function
    /// will call the game over menu and destroy the gameObject
    /// </summary>
    void Kill()
    {
        //Call appropriate menu
        Spawner.i.SpawnObject(Prefab.GameOverMenu);
        //Destroy this object
        Destroy(gameObject);
    }

    //Tracks boundary collisions and death events
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            isTouchingBoundary = true;
            _velocity.y = 0;
            SetFinalVelocity();
        }
        else
        {
            Kill();
        }
    }

    //Tracks boundary collisions
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            isTouchingBoundary = false;
        }
    }

    //Tracks collision with score zones and increments accordingly
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            GameManager.i.IncrementScore();
            Destroy(other);
        }
    }
}
