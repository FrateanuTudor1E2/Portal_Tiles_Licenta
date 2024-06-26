using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    [SerializeField] public AudioSource muteBG;
    private bool muted = false;
    private const string BGMUSIC_KEY = "Music";

    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt(BGMUSIC_KEY, 0) == 1;
        muteBG.mute = isMuted;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            bool isMuted = !muteBG.mute;
            muteBG.mute = isMuted;

            PlayerPrefs.SetInt(BGMUSIC_KEY, isMuted ? 1 : 0);
        }
    }

    
}
