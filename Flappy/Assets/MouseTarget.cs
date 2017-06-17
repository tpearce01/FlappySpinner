using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        gameObject.transform.position = mousePosition;
    }
	
	// Update is called once per frame
	void Update ()
	{
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
	    gameObject.transform.position = mousePosition;

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().angularVelocity = other.relativeVelocity.magnitude * 100;
    }
}
