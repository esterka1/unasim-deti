using UnityEngine;

public class Child : MonoBehaviour
{
    public void Interact()
    {
        GameManager.instance.StartQuest();
    }
}
