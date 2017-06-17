using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************
 * public class BoundaryController
 * 
 * Purpose: Controls the ceiling and floor boundaries of the 
 *      game space. Sets the position and size based on screen
 *      size.
 *****************************************************************/
public class BoundaryController : MonoBehaviour
{
    [SerializeField] private GameObject _upperBoundary; //Ceiling of the game space
    [SerializeField] private GameObject _lowerBoundary; //Floor of the game space

	// Initialize
	void Start () {
        SetPosition();
        SetSize();
    }

    /// <summary>
    /// Set the position of the boundaries based on screen size
    /// </summary>
    void SetPosition()
    {
        float unitHeight = (Screen.height / 2) / Camera.main.orthographicSize;
        _upperBoundary.transform.position = new Vector2(0, .09f * unitHeight);
        _lowerBoundary.transform.position = new Vector2(0, .09f * -unitHeight);
    }

    /// <summary>
    /// Set the size of the boundaries based on screen size
    /// </summary>
    void SetSize()
    {
        float unitWidth = (Screen.width / 2) / Camera.main.orthographicSize;
        _upperBoundary.GetComponent<BoxCollider2D>().size = new Vector2(.2f * unitWidth, .1f);
        _lowerBoundary.GetComponent<BoxCollider2D>().size = new Vector2(.2f * unitWidth, .1f);
    }
	
}
