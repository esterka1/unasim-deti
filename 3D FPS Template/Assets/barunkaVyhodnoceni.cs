using UnityEngine;
using TMPro;

public class barunkaVyhodnoceni : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public void CheckSoup()
    {
        if (dialogueText == null)
        {
            Debug.LogError("DialogueText není přiřazený v BarunkaVyhodnoceni!");
            return;
        }

        if (SoupData.addedIngredients == null)
        {
            dialogueText.text = "Nemáš žádnou polévku.";
            return;
        }

        bool hasSteak = SoupData.addedIngredients.Contains("steak");
        bool hasPotato = SoupData.addedIngredients.Contains("potato");
        bool hasLeek = SoupData.addedIngredients.Contains("leek");

        if (hasSteak && hasPotato && hasLeek && SoupData.addedIngredients.Count == 3)
        {
            dialogueText.text = "To je přesně ono!";
            FlowAfterSoup.instance.AfterCorrectFood();
        }
        else
        {
            dialogueText.text = "Tohle není ono.";
        }
    }
}