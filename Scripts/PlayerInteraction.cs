using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 1f; //Action range
    public LayerMask interactableLayer;
    public Transform carryPosition;
    private bool mouseToLeft = false;
    private bool isCarrying = false;
    private GameObject carriedObject;
    
    // Update is called once per frame
    void Update()
    {
        //Check if player near cube
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer); 
        foreach (Collider2D collider in hitColliders)
        {
            //Pick up cube
            if(Input.GetKeyDown(KeyCode.E) && !isCarrying)
            {
                PickUpObject(collider.gameObject);
                Debug.Log("Pick up");
                break;
            }
        }

        //Drop cube
        if(Input.GetKeyUp(KeyCode.E) && isCarrying)
        {
            DropObject();
            Debug.Log("Dropped");
        }
       
        UpdateCarriedObjectPosition();
        UpdateCarryPosition();
    }

    private void UpdateCarryPosition()
    {
        
            //Mouse position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Check if mouse is to the left of player
            bool newMouseToLeft = mousePos.x < transform.position.x;

            //Check for direction change 
            if (newMouseToLeft != mouseToLeft)
            {
               //Update carryPosition obj if direction changed
                if (newMouseToLeft)
                {
                    
                    carryPosition.position = new Vector3(transform.position.x - 1.3f, carryPosition.position.y, carryPosition.position.z);
                }
                else
                {
                    //Right of player change
                    carryPosition.position = new Vector3(transform.position.x + 1.3f, carryPosition.position.y, carryPosition.position.z);
                }

                //Update flag
                mouseToLeft = newMouseToLeft;
            }

       
    }
    private void DropObject()
    {
        isCarrying = false;
        //carriedObject.GetComponent<Rigidbody2D>().isKinematic = false; //Reactivate rb
        carriedObject = null;
    }

    private void PickUpObject(GameObject gameObject)
    {
        if (!isCarrying)
        {
            isCarrying = true;
            carriedObject = gameObject;
            // carriedObject.GetComponent<Rigidbody2D>().isKinematic = true; //Deactivate rb;
        }
    }
    private void UpdateCarriedObjectPosition()
    {
        if (isCarrying && carriedObject != null)
       {
           carriedObject.transform.position = carryPosition.position;
        }
    }
}
