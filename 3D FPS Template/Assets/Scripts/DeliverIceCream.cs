using UnityEngine;
using TMPro;

public class DeliverIceCream : MonoBehaviour
{
    public Dite1Vyhodnoceni dite1;
    public TextMeshProUGUI dialogueText;

    private bool playerIsNear = false;

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueText == null)
            {
                Debug.LogError("DialogueText není přiřazený!");
                return;
            }

            if (dite1 == null)
            {
                Debug.LogError("Dite1Vyhodnoceni není přiřazený!");
                return;
            }

            // první dialog
                    Debug.Log("Ice cream " + IceCreamData.dite1Talked);

            if (!IceCreamData.dite1Talked)
            {
                IceCreamData.dite1Talked = true;

                dialogueText.text =
                    "Mám chut na jahodovo-bananovou zmrzlinu...";
                Debug.Log("dialog1");
            }
            // vyhodnocení
            else
            {
                dite1.CheckIceCream();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;

            if (dialogueText == null)
                return;

            if (!IceCreamData.dite1Talked)
            {
                dialogueText.text = "Press E to talk";
            }
            else
            {
                dialogueText.text = "Press E to give ice cream";
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