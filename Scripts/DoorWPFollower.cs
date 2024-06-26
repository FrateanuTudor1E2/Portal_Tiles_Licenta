using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWPFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private bool activated = false;
    private bool arrived = false;

    public void Activate()
    {
        //Update flags
        activated = true;
        arrived = false;
        
    }
    public void Deactivate()
    {
        //Update flags
        activated = false;
        arrived = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!arrived)
        {
            if (activated)//Check if door is activated
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position, Time.deltaTime * speed);
                arrived = false;//Update flag
                if (transform.position == waypoints[1].transform.position)//check if door arrived at waypoint
                {
                    arrived = true;
                }

            }
            else//Go back to deactivated waypoint
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position, Time.deltaTime * speed);
                arrived = false;
                if (transform.position == waypoints[1].transform.position)
                {
                    arrived = true;
                }
            }
            }
    }
}
