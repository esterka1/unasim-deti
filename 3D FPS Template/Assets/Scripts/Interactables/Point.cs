using UnityEngine;

public class Point : Interactable
{
    public int score = 10;

    // When player interacts with the point object, it adds score to the player and destroys itself
    public override void Interact(Collider other)
    {
        base.Interact(other);
        other.GetComponent<Player>()?.AddScore(score);
        Destroy(gameObject);
    }
}
