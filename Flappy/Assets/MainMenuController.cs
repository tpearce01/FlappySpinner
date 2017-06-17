using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*********************************************************************************
 * class MainMenuController
 * 
 * Function: Controls the functionality of the main menu
 *********************************************************************************/
public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject scoresPanel;

    void Start()
    {
        Screen.SetResolution(320,568,false);
    }

    /// <summary>
    /// Load the "GameTest" scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("GameTest");
    }

    /// <summary>
    /// Set the scoresPanel active to see high scores
    /// </summary>
    public void CheckScores()
    {
        scoresPanel.SetActive(!scoresPanel.activeSelf);
    }
}
