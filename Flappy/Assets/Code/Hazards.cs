using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************
 * public class Hazards
 * 
 * Purpose: Controls the spawning and cleanup of Hazard objects.
 *      Hazard cleanup boundary is set to the left, off screen
 *      and will destroy any hazard objects it touches.
 *****************************************************************/
public class Hazards : MonoBehaviour
{
    [SerializeField] private GameObject _hazardPrefab;      //Prefab of the Hazard object
    [SerializeField] private float _timeBetweenHazards;     //Time between each hazard spawn
    [SerializeField] private float _timeUntilHazard;        //Time until the next hazard is spawned
    [SerializeField] private GameObject _cleanupBoundary;   //Boundary which destroys hazards that are 
                                                            //  no longer needed
    private float unitWidth;                                //Screen width
    [SerializeField] private int heightVariance;            //Min/Max Y position of spawned hazards
	
    // Initialize boundary size and position
	void Start () {
        unitWidth = (Screen.width / 2) / Camera.main.orthographicSize;
        InitializeCleanupBoundary();
    }

    /// <summary>
    /// Sets the position and size of the cleanup boundary based on screen size
    /// </summary>
    void InitializeCleanupBoundary()
    {
        float unitHeight = (Screen.height / 2) / Camera.main.orthographicSize;
        _cleanupBoundary.transform.position = new Vector2(-.2f * unitWidth, 0);
        _cleanupBoundary.GetComponent<BoxCollider2D>().size = new Vector2(.1f, .2f * unitHeight);
    }

    // Update is called once per frame
    void Update () {
	    if (_timeUntilHazard > 0)
	    {
	        _timeUntilHazard -= Time.deltaTime;
	    }
	    else
	    {
	        SpawnHazard();
	        _timeUntilHazard = _timeBetweenHazards;
	    }
	}

    void SpawnHazard()
    {
        Instantiate(_hazardPrefab, new Vector3(.2f * unitWidth, Random.Range(-heightVariance, heightVariance), 0), Quaternion.identity);
    }
}
