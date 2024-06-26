using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrangePortal : MonoBehaviour
{
    [SerializeField] private GameObject orangePortalPrefab;
    private GameObject orangePortal;
    private GameObject bluePortal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalSurface")) // Check if the collision is on right surface
        {
           
            DeleteObjectsWithTag("OrangePortal"); // Destroy previous portal

            Vector2 spawnPosition = collision.transform.position;
            Quaternion spawnRotation = collision.transform.rotation;

            SpawnPortal(orangePortalPrefab, spawnPosition, spawnRotation); // Spawn the portal prefab with "spawnPosition" and spawnRotation params

        }
        else if (collision.CompareTag("BluePortal")) // Check if there is a blue portal
        {
            DeleteObjectsWithTag("OrangePortal"); // Destroy previous portal
            DeleteObjectsWithTag("BluePortal"); // Destroy the blue portal so that the "PortalSurface" is clean
            Vector2 spawnPosition = collision.transform.position;
            Quaternion spawnRotation = collision.transform.rotation;

            SpawnPortal(orangePortalPrefab, spawnPosition, spawnRotation); 

        }
    }
    private void DeleteObjectsWithTag(string tag) // Delete all GameObjects with the same "tag"
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    private void SpawnPortal(GameObject portalPrefab, Vector2 position, Quaternion rotation) // Spawn a portal
    {
        orangePortal = Instantiate(portalPrefab, position, rotation);
        

    }


}