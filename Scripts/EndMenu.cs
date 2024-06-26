using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Same as "StartMenu" script

public class EndMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    public void ClickOn()
    {
        clickSound.Play();
        Invoke("Quit", 1f); // Calls "Quit" method affter delay
    }
    private void Quit()
    {
        Application.Quit(); // Exit application
    }
}
