using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public Color activatedColor;
    public Color deactivatedColor;
    private SpriteRenderer spriteRenderer;
    public PressurePlateAct PressurePlateAct;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cube"))
        {
            Debug.Log("Cube Detected");
            spriteRenderer.color = activatedColor;
            PressurePlateAct.ActivateDoor();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Cube"))
        {
            Debug.Log("Cube Left");
            spriteRenderer.color = deactivatedColor;
            PressurePlateAct.DeactivateDoor();
        }

    }
}
