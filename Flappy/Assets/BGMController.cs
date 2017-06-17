using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    foreach (GameObject go in GameObject.FindGameObjectsWithTag("BGM"))
	    {
	        if (go != gameObject)
	        {
	            Destroy(go);
	        }
	    }
	    DontDestroyOnLoad(gameObject);

	}
}
