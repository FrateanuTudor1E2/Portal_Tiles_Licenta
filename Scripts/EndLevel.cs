using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;
    private int levelIndex;
    private void Start()
    {   levelIndex = SceneManager.GetActiveScene().buildIndex;
        finishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            finishSound.Play();
            Invoke("CompleteLevel", 1f);
            
        }
    }

    private void CompleteLevel()
    {
        LevelManager.CompleteLevel(levelIndex); // Updates CompletedLevels and UnlockedLevels KEYS
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
