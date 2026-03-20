using Core;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    private float _currentHealth;
    private int _score;
    private Vector3 respawnPoint = Vector3.zero;
    public AudioSource  audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip scoreSound;
    private CharacterController _characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = maxHealth;
        _characterController = GetComponent<CharacterController>();
    }
    
    // Nastavení respawn pointu na novou pozici
    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    // Adding score and updating the UI
    public void AddScore(int number)
    {
        _score += number;
        Interface.Instance.ShowScore(_score);
        PlaySound(scoreSound);
    }
    
    // Function for taking damage
    public void TakeDamage(float amount, float strength, Vector3 origin)
    {
        // Take damage
        Debug.Log ("Player get damage");
        _currentHealth -= amount;
        // Update health UI
        Interface.Instance.ShowHealth(_currentHealth,maxHealth);
        // Knockback
        Vector3 knockback = (transform.position - (Vector3)origin).normalized * strength;
        if (_characterController != null && _characterController.enabled)
        {
            _characterController.Move(knockback);
        }
        else
        {
            transform.position += knockback;
        }
        // Sound
        PlaySound(damageSound);
        
        // Check for death
        if (_currentHealth <= 0)
        {
            // Kill the player
            Die();
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            return;
        audioSource.PlayOneShot(clip);
    }

    // for now the player just respawns at the last respawn point, instead of dying
    private void Die()
    {
        Debug.Log("hráč zemřel");
        RespawnAt(respawnPoint);
        _currentHealth = maxHealth;
        Interface.Instance.ShowHealth(_currentHealth, maxHealth);
    }

    private void RespawnAt(Vector3 position)
    {
        // Disable CharacterController so it won't override our teleport this frame.
        if (_characterController != null)
        {
            _characterController.enabled = false;
        }

        transform.position = position;
        Physics.SyncTransforms();

        if (_characterController != null)
        {
            _characterController.enabled = true;
        }
    }
}
