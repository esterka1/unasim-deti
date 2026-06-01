using UnityEngine;
using TMPro;

public class Dite1Vyhodnoceni : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public static bool dite1ObjednavkaPrijata = false;

    void OnApplicationQuit()
    {
            IceCreamData.delalIcecream = false;
            IceCreamData.finished = false;
            IceCreamData.dite1Talked = false;
    }

    public void CheckIceCream()
    {
        if(IceCreamData.finished)
            return;

        if (dialogueText == null)
        {
            Debug.LogError("DialogueText není přiřazený v Dite1Vyhodnoceni!");
            return;
        }

        if (IceCreamData.addedIngredients == null || IceCreamData.delalIcecream == false)
        {
            dialogueText.text = "Nemáš žádnou zmrzlinu.";
            return;
        }

        bool hasStrawberry =
            IceCreamData.addedIngredients.Contains("Strawberry");

        bool hasBanana =
            IceCreamData.addedIngredients.Contains("Banana");

        if (hasStrawberry &&
            hasBanana &&
            IceCreamData.addedIngredients.Count == 2)
        {
            dialogueText.text =
                "Dik";
                IceCreamData.addedIngredients.Clear();
                IceCreamData.dite1Talked = false;
                IceCreamData.finished = true;
        }
        else
        {
            dialogueText.text =
                "Umm... to není to co jsem chtěl...";
                IceCreamData.addedIngredients.Clear();
                IceCreamData.dite1Talked = false;
        }
    }
}