using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    WriteScores theScript;

    public Text livesText;

    private bool gameHasEnded = false;

    public AudioSource audioSource;
    public Toggle toggleButton;

    private bool isPlaying = true;

    public GameObject pauseMenu;
    public bool isPaused;
    public Text playerName;

    void Start() 
    {
        playerName.text = "Good Luck: " + Menu.myName + "!";
        audioSource.Play();
        theScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<WriteScores>();
   
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ToggleMusic()
    {
        if (toggleButton.isOn)
        {
            // Resume music
            audioSource.UnPause();
            isPlaying = true;
        }
        else
        {
            // Pause music
            audioSource.Pause();
            isPlaying = false;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1Intro");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("2Game");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("3Exit");
        theScript.AddNewScore();
    }

}
