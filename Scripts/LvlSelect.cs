using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LvlSelect : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    private int lvlNum;
    public void TestLVL()
    {
        clickSound.Play();
        lvlNum = 1;
        Invoke("Game", 1f); // Calls the "Game" method after delay
      
    }
    
    public void SelectLVL()
    {
        clickSound.Play();
        lvlNum = SceneManager.sceneCountInBuildSettings - 1;
        Invoke("Game", 0.5f);
    }
    public void Back()
    {
        clickSound.Play();
        lvlNum = 0;
        Invoke("Game", 0.5f);
    }

    // Each level  has a specific method
    public void Level1()
    {
        clickSound.Play();
        lvlNum = 2;
        Invoke("Game", 1f);
    }

    public void Level2()
    {
        clickSound.Play();
        lvlNum = 3;
        if (LevelManager.IsLevelUnlocked(lvlNum))
            Invoke("Game", 1f);
    }

    public void Level3()
    {
        clickSound.Play();
        lvlNum = 4;
        if (LevelManager.IsLevelUnlocked(lvlNum))
            Invoke("Game", 1f);
    }

    public void Level4()
    {
        clickSound.Play();
        lvlNum = 5;
        if (LevelManager.IsLevelUnlocked(lvlNum))
            Invoke("Game", 1f);
    }

    public void Level5()
    {
        clickSound.Play();
        lvlNum = 6;
        if (LevelManager.IsLevelUnlocked(lvlNum))
            Invoke("Game", 1f);
    }
    private void Game()
    {
        print("game");
        SceneManager.LoadScene(lvlNum); // Load level based on lvlNum
    }
}
