using System;
using UnityEngine;

public class Checkpoint : Interactable
{
    [Header("Portal Settings")]
    [Tooltip("The location where the player will be teleported to when interacting with the portal. / Pozice, kam bude hráč teleportován po interakci s portálem.")]
    public Vector3 checkpointPosition = Vector3.zero;
    
  
    public override void Interact(Collider other)
    {
        base.Interact(other);
        other.GetComponent<Player>()?.SetRespawnPoint(GetCheckpointPosition());
    }
    
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GetCheckpointPosition(), 0.3f);
    }

    private Vector3 GetCheckpointPosition()
    {
        return transform.position + checkpointPosition;
    }
}
