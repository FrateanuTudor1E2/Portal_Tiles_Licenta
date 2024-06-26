using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;

    public void ClickOn()
    {
        clickSound.Play();
        Invoke("ResetLevels", 1f); 
    }
    private void ResetLevels()
    {
        PlayerPrefs.DeleteKey("UnlockedLevels");
        PlayerPrefs.DeleteKey("CompletedLevels");
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
