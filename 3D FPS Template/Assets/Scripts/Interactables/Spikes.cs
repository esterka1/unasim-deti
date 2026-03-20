using UnityEngine;

public class Spikes : Interactable
{
    [Header("Spike Settings")]
    [Tooltip(
        "How much damage the spikes will deal to the player upon contact. / Kolik poškození způsobí hráči při kontaktu s trny.")]
    public float damageAmount = 10f;
    [Tooltip(
        "How much the player will get pushed away upon contact. / Jak moc hráče posune když se jich dotkne.")]
    public float pushAmount = .01f;
    [Tooltip("Minimum time between hits on the same player across all spikes.")]
    public float hitCooldown = 0.5f;

    private static readonly System.Collections.Generic.Dictionary<int, float> _lastHitTimeByPlayer
        = new System.Collections.Generic.Dictionary<int, float>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStaticState()
    {
        _lastHitTimeByPlayer.Clear();
    }

    public override void Interact(Collider other)
    {
        base.Interact(other);
        var player = other.GetComponentInParent<Player>();
        if (player == null)
        {
            return;
        }

        int id = player.GetInstanceID();
        if (_lastHitTimeByPlayer.TryGetValue(id, out float lastHitTime))
        {
            if (Time.time - lastHitTime < hitCooldown)
            {
                Debug.Log("Běží cooldown");
                return;
            }
        }
        _lastHitTimeByPlayer[id] = Time.time;
        player.TakeDamage(damageAmount, pushAmount, transform.position);
    }
}
