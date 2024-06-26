using System.Collections;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public float teleportCooldown = 1f;
    private bool canTeleport = true;
    [SerializeField] private AudioSource teleportSoundEffect;
    public Vector3 teleportOffset = Vector3.zero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport)
        {
            if (collision.CompareTag("BluePortal")) // Teleport to orange portal
            {
                GameObject orangePortal = GameObject.FindGameObjectWithTag("OrangePortal");
                if (orangePortal != null)
                {
                    StartCoroutine(TeleportCoroutine(orangePortal.transform));
                }
            }
            else if (collision.CompareTag("OrangePortal")) // Teleport to blue portal
            {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("BluePortal");
                if (bluePortal != null)
                {
                    StartCoroutine(TeleportCoroutine(bluePortal.transform));
                }
            }
        }
    }

    private IEnumerator TeleportCoroutine(Transform destination)
    {
        canTeleport = false;
        teleportSoundEffect.Play();
        // Check if the destination portal is rotated
        float rotationZ = destination.eulerAngles.z;

        // Determine the spawn offset based on the rotation
        Vector3 spawnOffset = Vector3.zero;
        if (rotationZ == -90f)
        {
            spawnOffset = Vector3.down + teleportOffset;
        }
        else if (rotationZ == 90f)
        {
         
            spawnOffset = Vector3.up + teleportOffset;
        }
        else if (rotationZ == 180f || rotationZ == -180f)
        {
            spawnOffset = Vector3.left + teleportOffset;
        }
        else if (rotationZ == 0f)
        {
            spawnOffset = Vector3.right + teleportOffset;
        }
        else
        {
            spawnOffset = teleportOffset; // If rotation is different, just use the teleportOffset
        }
        // Teleport the player to the destination
        transform.position = destination.position + spawnOffset;

        // Cooldown to avoid having the player looping between portals
        yield return new WaitForSeconds(teleportCooldown);

        canTeleport = true;
    }
}
