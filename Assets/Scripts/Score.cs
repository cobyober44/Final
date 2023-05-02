using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public int myLives;
    public int myPoints;
}

public class Score : MonoBehaviour
{

    private GameData gameData;

    public Text pointsText;

    public int maxPoints = 100000;
    public int minPoints = -100000;
    public static int points;

    public Text livesText;

    public int maxLives = 9;
    public int minLives = 1;
    public static int lives;

    WriteScores theScript;

    void Start()
    {
        LoadGameData();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddPoints(10);
            AddLives(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddPoints(-10);
            AddLives(-1);
        }

    }

    public void IncreasePoints()
    {
        AddPoints(10);
    }

    public void DecreasePoints()
    {
        AddPoints(-10);
    }

    private void AddPoints(int amount)
    {
        points += amount;
        if (points > maxPoints)
        {
            points = maxPoints;
        }
        else if (points < minPoints)
        {
            points = minPoints;
        }
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();
    }

    public void IncreaseLives()
    {
        AddLives(1);
    }

    public void DecreaseLives()
    {
        AddLives(-1);
    }

    private void AddLives(int amount)
    {
        lives += amount;
        if (lives > maxLives)
        {
            lives = maxLives;
        }
        else if (lives < minLives)
        {
            lives = minLives;
        }
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        livesText.text = lives.ToString();
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetInt("lives", gameData.myLives);
        PlayerPrefs.SetInt("points", gameData.myPoints);
        PlayerPrefs.Save();

        Debug.Log("Game data saved.");
    }

    public void LoadGameData()
    {
        gameData = new GameData();
        gameData.myLives = PlayerPrefs.GetInt("lives", lives);
        gameData.myPoints = PlayerPrefs.GetInt("points", points);

        Debug.Log("Game data loaded. Lives: " + gameData.myLives + ", Points: " + gameData.myPoints);
    }

    public void SaveGameDataAsJSON()
    {
        string jsonData = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("gameDataJSON", jsonData);

        Debug.Log("Game data saved as JSON: " + jsonData);
    }
}

