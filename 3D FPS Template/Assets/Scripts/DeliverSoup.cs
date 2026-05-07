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
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;

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
            dialogueText.text = "";
        }
    }
}