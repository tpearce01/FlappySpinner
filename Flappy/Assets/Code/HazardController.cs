using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************
 * public class HazardController
 * 
 * Purpose: Controls the movement and behaviors of hazard objects
 *****************************************************************/
public class HazardController : MonoBehaviour
{
    [SerializeField] private int _moveSpeed;
    [SerializeField] private Rigidbody2D rgbd;
	
	// Update is called once per frame
	void Start ()
	{
	    Move();
	}

    void Move()
    {
        rgbd.velocity = new Vector2(-_moveSpeed,0);
    }
}
