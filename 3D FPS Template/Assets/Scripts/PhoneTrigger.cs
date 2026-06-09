using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlowAfterSoup.instance.PlayerEnteredPhone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlowAfterSoup.instance.PlayerLeftPhone();
        }
    }
}