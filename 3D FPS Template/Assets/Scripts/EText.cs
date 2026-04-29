using UnityEngine;

public class ShowPressE : MonoBehaviour
{
    public GameObject pressEText;

    private void Start()
    {
        pressEText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressEText.SetActive(false);
        }
    }
}