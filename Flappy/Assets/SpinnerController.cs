using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float bpm;
    private float timeBetweenBeats;
    private float timeUntilNextBeat;
    [SerializeField] private int pop;
	// Use this for initialization
	void Start ()
	{
	    rgbd.angularVelocity = rotationSpeed;
	    timeBetweenBeats = 60f/bpm;
	    timeUntilNextBeat = timeBetweenBeats;
	}
	
	// Update is called once per frame
	void Update () {
	    if (timeUntilNextBeat <= 0f)
	    {
	        timeUntilNextBeat += timeBetweenBeats;
	        StartCoroutine(Pop(pop));
	    }
	    else
	    {
	        timeUntilNextBeat -= Time.deltaTime;
	    }
	}

    IEnumerator Pop(int v)
    {
        Vector3 baseLS = gameObject.transform.localScale;
        for (int i = 0; i < v; i++)
        {
            gameObject.transform.localScale = gameObject.transform.localScale * 1.1f;
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < v; i++)
        {
            gameObject.transform.localScale = gameObject.transform.localScale * 0.9f;
            yield return new WaitForFixedUpdate();
        }
        gameObject.transform.localScale = baseLS;
        yield return null;
    }
}
