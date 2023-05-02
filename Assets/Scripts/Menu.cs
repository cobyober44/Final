using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public InputField playerName;
    public Text nameText;
    public static string myName = "You";

    public Dropdown livesDropdown;
    public static int lives;

    public void StartGame()
    {
        SceneManager.LoadScene("2Game");
    }

    public void InputName()
    {
        myName = playerName.text.ToString();
        nameText.text = myName.ToUpper();
    }

    public void ChangeLives()
    {
        switch (livesDropdown.value)
        {
            case 1:
                lives = 2;
                break;
            case 2:
                lives = 3;
                break;
            case 3:
                lives = 4;
                break;
            case 4:
                lives = 5;
                break;
            case 5:
                lives = 6;
                break;
            case 6:
                lives = 7;
                break;
            case 7:
                lives = 8;
                break;
            case 8:
                lives = 9;
                break;
            case 9:
                lives = 10;
                break;
        }

    }

}

