using UnityEngine;

public class ChildPrompt : MonoBehaviour
{
    public GameObject talkPrompt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talkPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talkPrompt.SetActive(false);
        }
    }
}
