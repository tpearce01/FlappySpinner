using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

/*********************************************************************************
 * public class GameOverManager
 * 
 * Function: Control Game Over Menu functionality. Should pause the game when 
 *      created and allow the player to restart the game. Will also display
 *      the score achieved, and wether or not it was a new high score.
 *********************************************************************************/
public class GameOverManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;

    //Get static reference and pause the game
    void Awake()
    {
        //Pause the game
        Time.timeScale = 0;
        _scoreText.text = "Score: " + GameManager.i.score;
        switch (GameManager.i.GetScorePlacing())
        {
            case 1:
                _scoreText.text += "\nNew High Score!";
                //Display gold medal;
                SaveScore(GameManager.i.score);
                break;
            case 2:
                //display silver medal
                SaveScore(GameManager.i.score);
                break;
            case 3:
                //display bronze medal
                SaveScore(GameManager.i.score);
                break;
        }
    }

    /// <summary>
    /// Restart the active scene
    /// </summary>
	public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveScore(int s)
    {
        int[] scores = GameManager.i.highScoreCache; //Cached scores
        int temp; //Store temporary score value
        //Iterate through the list and insert the new score where appropriate. The smallest 
        //  value will not be included in the final array. O(n).
        for (int i = 0; i < scores.Length; i++)
        {
            if (s > scores[i])
            {
                temp = scores[i];
                scores[i] = s;
                s = temp;
            }
        }
        StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/PlayerData.txt");
        sr.WriteLine(scores[0].ToString() + ',' + scores[1].ToString() + ',' + scores[2].ToString());
        sr.Close();
        for (int i = 0; i < scores.Length; i++)
        {
            GameManager.i.highScoreCache[i] = scores[i];
        }
        GameManager.i.highScoreCache = scores;
    }
}
