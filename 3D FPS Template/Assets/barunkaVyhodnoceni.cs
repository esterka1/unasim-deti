using UnityEngine;
using TMPro;

public class barunkaVyhodnoceni : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public void CheckSoup()
    {
        bool hasSteak = SoupData.addedIngredients.Contains("steak");
        bool hasPotato = SoupData.addedIngredients.Contains("potato");
        bool hasLeek = SoupData.addedIngredients.Contains("leek");

        if (hasSteak && hasPotato && hasLeek && SoupData.addedIngredients.Count == 3)
        {
            dialogueText.text = "To je přesně ono!";
        }
        else
        {
            dialogueText.text = "Tohle není ono…";
        }
    }
}