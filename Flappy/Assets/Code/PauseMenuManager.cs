using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*********************************************************************************
 * public class PauseMenuManager
 * 
 * Function: Controls all pause menu functionality
 *********************************************************************************/
public class PauseMenuManager : MonoBehaviour
{
    //Get static reference and pause the game
    void Awake()
	{
        //Pause the game
	    Time.timeScale = 0;
	}

    /// <summary>
    /// Return time scale to normal and destroy the pause menu
    /// </summary>
    public void Resume(){
		Time.timeScale = 1;
		Destroy (gameObject);
	}

    /// <summary>
    /// Restart the active scene
    /// </summary>
	public void Restart(){
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
