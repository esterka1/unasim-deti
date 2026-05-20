using UnityEngine;

public class Child : MonoBehaviour
{
    public void Interact()
    {
        if (GameManager.instance.state == GameState.GoToChild)
        {
            GameManager.instance.StartQuest();
        }
        else if (GameManager.instance.state == GameState.ReturnToChild)
        {
            GameManager.instance.DeliverToy();
        }
    }
}