using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelController : MonoBehaviour {

    //int[] scores = new int[3];
    [SerializeField] Text scoreText;

    void OnEnable()
    {
        if (!File.Exists(Application.persistentDataPath + "/PlayerData.txt"))
        {
            StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerData.txt");
            sr.WriteLine("0,0,0");
            scoreText.text = "0\n0\n0";
            sr.Close();
        }
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
        string rawData = reader.ReadLine();
        string[] data = rawData.Split(',');
        reader.Close();
        scoreText.text = data[0] + '\n' + data[1] + '\n' + data[2];
    }
}
