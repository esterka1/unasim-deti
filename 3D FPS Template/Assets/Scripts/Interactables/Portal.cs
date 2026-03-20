using System;
using UnityEngine;

public class Portal : Interactable
{
    [Header("Portal Settings")]
    [Tooltip("The location where the player will be teleported to when interacting with the portal. / Pozice, kam bude hráč teleportován po interakci s portálem.")]
    public Vector3 teleportLocation = Vector3.zero;

    public override void Interact(Collider other)
    {
        base.Interact(other);
        // Teleport the player to the specified location
        other.transform.position = teleportLocation;
    }

    private void OnDrawGizmos() // Shows a debug sphere where to teleport player
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(teleportLocation, 0.3f);
    }
}
