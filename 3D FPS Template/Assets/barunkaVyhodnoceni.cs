using UnityEngine;

public class barunkaVyhodnoceni : MonoBehaviour
{
    public void CheckSoup()
    {
        if (SoupData.addedIngredients.Contains("meat"))
        {
            Debug.Log("To je výborný… děkuju.");
        }
        else
        {
            Debug.Log("Tohle… není ono…");
        }
    }
}