using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is run when "Start" button is clicked on by the user

public class StartMenu : MonoBehaviour
{ 
   [SerializeField] private AudioSource clickSound;
    public void StartGame()
    {
        print("startgame");
        clickSound.Play();
        Invoke("Game", 1f); // Calls the "Game" method after delay
    }
    private void Game()
    {
        print("game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Load lvl1
    }
}
