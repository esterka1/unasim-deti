using UnityEngine;
using TMPro;

public class DeliverSoup : MonoBehaviour
{
    public barunkaVyhodnoceni barunka;
    public TextMeshProUGUI dialogueText;

    private bool playerIsNear = false;

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueText == null)
            {
                Debug.LogError("DialogueText není přiřazený v DeliverSoup!");
                return;
            }

            if (barunka == null)
            {
                Debug.LogError("Barunka není přiřazená v DeliverSoup!");
                return;
            }

            if (!SoupData.barunkaTalked)
            {
                SoupData.barunkaTalked = true;
                dialogueText.text = "Děti měly steak... dlouho jsem steak neměla...";
            }
            else
            {
                barunka.CheckSoup();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER: " + other.name + " tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;

            if (dialogueText == null)
            {
                Debug.LogError("DialogueText není přiřazený v DeliverSoup!");
                return;
            }

            if (!SoupData.barunkaTalked)
            {
                dialogueText.text = "Zmáčkni E a promluv s Barunkou";
            }
            else
            {
                dialogueText.text = "Zmáčkni E pro předání polévky";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;

            if (dialogueText != null)
            {
                dialogueText.text = "";
            }
        }
    }
}