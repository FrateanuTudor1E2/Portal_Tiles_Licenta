
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBluePortal : MonoBehaviour
{
    [SerializeField] private GameObject bluePortalPrefab;
    private GameObject bluePortal;
    private GameObject orangePortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalSurface"))// Check if the collision is on right surface
        {
            
            DeleteObjectsWithTag("BluePortal");// Destroy previous portal

            Vector2 spawnPosition = collision.transform.position;
            Quaternion spawnRotation = collision.transform.rotation;
     
            SpawnPortal(bluePortalPrefab, spawnPosition, spawnRotation);// Spawn the portal prefab with "spawnPosition" and spawnRotation params


        }
        else if (collision.CompareTag("OrangePortal"))// Check if there is an orange portal
        {
            DeleteObjectsWithTag("OrangePortal");// Destroy the orange portal so that the "PortalSurface" is clean
            DeleteObjectsWithTag("BluePortal");// Destroy previous portal

            Vector2 spawnPosition = collision.transform.position;
            Quaternion spawnRotation = collision.transform.rotation;
     
            SpawnPortal(bluePortalPrefab, spawnPosition, spawnRotation);

      
        }
    }
    private void DeleteObjectsWithTag(string tag)// Delete all GameObjects with the same "tag"
    {

      
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    private void SpawnPortal(GameObject portalPrefab, Vector2 position, Quaternion rotation)// Spawn a portal
    {
        bluePortal = Instantiate(portalPrefab, position, rotation);
        
    }

  
}
