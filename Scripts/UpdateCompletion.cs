using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCompletion : MonoBehaviour
{
    public Color LockUnlockColor;
    public Color ButtonUnlockColor;
    public GameObject GameObject;
    private SpriteRenderer spriteRenderer;
    public Image image;
    public int index;
    void Start()
    { 
        // Update the sprites of the buttons if the corresponfing levels are unlocked
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (LevelManager.IsLevelUnlocked(index))
        {
            spriteRenderer.color = LockUnlockColor;
            image.color = ButtonUnlockColor;
           
        }   
    }

}
