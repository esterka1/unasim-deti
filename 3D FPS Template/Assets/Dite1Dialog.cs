using UnityEngine;
using TMPro;

public class Dite1Dialog : MonoBehaviour
{
    [Header("UI")]
    public GameObject pressEText;
    public TMP_Text dialogText;

    [Header("Dialog")]
    public string message = "Mám chuť na jahodovo-bananovou zmrzlinu...";

    // Tohle říká ostatním scriptům,
    // že dítě už zadalo objednávku
    public static bool dite1ObjednavkaPrijata = false;

    private bool playerNear = false;
    private bool hasTalked = false;

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
            TalkToChild();
        }
    }

    void TalkToChild()
    {
        if (dialogText != null)
            dialogText.text = message;

        // objednávka aktivní
        dite1ObjednavkaPrijata = true;

        hasTalked = true;

        if (pressEText != null)
            pressEText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerNear = true;

            if (pressEText != null)
                pressEText.SetActive(true);
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
}