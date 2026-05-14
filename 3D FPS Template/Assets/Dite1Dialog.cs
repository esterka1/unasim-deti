using UnityEngine;
using TMPro;

public class Dite1Dialog : MonoBehaviour
{
    [Header("UI")]
    public GameObject pressEText;
    public TMP_Text pressELabel;
    public TMP_Text dialogText;

    [Header("Dialog")]
    public string firstMessage = "Mám chuť na jahodovo-bananovou zmrzlinu...";
    public string correctMessage = "Děkuju moc... To je přesně to co jsem chtěl.";
    public string wrongMessage = "Umm... to není to co jsem chtěl...";

    public static bool dite1ObjednavkaPrijata = false;

    private bool playerNear = false;
    private bool hasTalked = false;
    private bool hasEvaluated = false;

    void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false);

        if (dialogText != null)
            dialogText.text = "";
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasTalked)
            {
                TalkToChild();
            }
            else if (!hasEvaluated && IceCreamData.addedIngredients.Count > 0)
            {
                EvaluateIceCream();
            }
        }
    }

    void TalkToChild()
    {
        if (dialogText != null)
            dialogText.text = firstMessage;

        dite1ObjednavkaPrijata = true;
        hasTalked = true;

        if (pressEText != null)
            pressEText.SetActive(false);
    }

    void EvaluateIceCream()
    {
        Debug.Log("=== KONTROLUJU ZMRZLINU ===");

foreach (string ingredient in IceCreamData.addedIngredients)
{
    Debug.Log("Ingredience v datech: " + ingredient);
}
        bool hasStrawberry = IceCreamData.addedIngredients.Contains("Strawberry");
        bool hasBanana = IceCreamData.addedIngredients.Contains("Banana");

        bool correctIceCream =
            hasStrawberry &&
            hasBanana &&
            IceCreamData.addedIngredients.Count == 2;

        if (correctIceCream)
        {
            if (dialogText != null)
                dialogText.text = correctMessage;

            Debug.Log("SPRÁVNÁ ZMRZLINA");
        }
        else
        {
            if (dialogText != null)
                dialogText.text = wrongMessage;

            Debug.Log("ŠPATNÁ ZMRZLINA");
        }

        Debug.Log("Ingredience ve zmrzlině:");
        foreach (string ingredient in IceCreamData.addedIngredients)
        {
            Debug.Log(ingredient);
        }

        hasEvaluated = true;

        if (pressEText != null)
            pressEText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!hasTalked)
            {
                ShowPressE("Press E to talk");
            }
            else if (!hasEvaluated && IceCreamData.addedIngredients.Count > 0)
            {
                ShowPressE("Press E to give ice cream");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (pressEText != null)
                pressEText.SetActive(false);
        }
    }

    void ShowPressE(string text)
    {
        if (pressEText != null)
            pressEText.SetActive(true);

        if (pressELabel != null)
            pressELabel.text = text;
    }
}