using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager i;                    //Static reference to this script
    public int score;                               //Current score
    public int[] highScoreCache;                    //Highest score according to local data
    [SerializeField] private TextMesh _scoreText;   //In-game score display

	void Awake ()
	{
	    i = this;
	    score = 0;

        //Get cached high score
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
        string rawData = sr.ReadLine();
        string[] data = rawData.Split(',');
        sr.Close();

        highScoreCache = new int[data.Length];
	    for (int j = 0; j < data.Length; j++)
	    {
	        highScoreCache[j] = Convert.ToInt32(data[j]);
	    }
    }

    public void IncrementScore()
    {
        score++;
        _scoreText.text = score.ToString();
    }

    public int GetScorePlacing()
    {
        if (score > highScoreCache[0])
        {
            return 1;
        }
        if(score > highScoreCache[1])
        {
            return 2;
        }
        if (score > highScoreCache[2])
        {
            return 3;
        }

        return 4;
    }

    public void SetScores()
    {
        int tempScore = -1;
        for (int j = 0; j < highScoreCache.Length; j++)
        {
            if (score > highScoreCache[j])
            {
                tempScore = highScoreCache[j];
                highScoreCache[j] = score;
                score = tempScore;
            }
        }
    }
}
