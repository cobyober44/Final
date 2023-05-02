using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class ReadScores : MonoBehaviour
{
    public Text HighScores;
    public int num_scores = 10;

    void Start()
    {
        ShowTopScores();
    }

    public void ShowTopScores()
    {
        string path = "Assets/Scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];

        int scores_read = 0;

        HighScores.text = "";
        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScores.text += fields[0] + "  -  " + fields[1] + "\n";
            scores_read += 1;
        }
    }
}