using System;
using UnityEngine;

public class Key : Interactable
{
    [Tooltip("The door that this key opens. / Dveře, které tento klíč otevírá.")]
    public Door door;

    // Warn if no door is assigned
    public void Start()
    {
        if (door == null)
            Debug.LogWarning($"The Key {gameObject} has no door assigned");
    }

    // When player interacts with the key, it unlocks the door and destroys itself
    public override void Interact(Collider other)
    {
        base.Interact(other);
        door.Unlock();
        Debug.Log($"The Key {gameObject} unlocked the door {door}");
        Destroy(gameObject);
    }
}
