using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAct : MonoBehaviour
{
    public Color activatedColor;
    public Color deactivatedColor;
    private SpriteRenderer spriteRenderer;
    public DoorWPFollower DoorWPFollower;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ActivateDoor()
    {
        spriteRenderer.color = activatedColor;
        DoorWPFollower.Activate();
 
    }

    public void DeactivateDoor()
    {
        spriteRenderer.color = deactivatedColor;
        DoorWPFollower.Deactivate();
    }
  
}
