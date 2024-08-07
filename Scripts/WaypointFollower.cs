using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour 
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
       sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // Logic for the "Saw" traps and for the "Platforms" to follow a predetermined path

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f )
        {
            currentWaypointIndex++;
            sprite.flipX = true;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                sprite.flipX = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
