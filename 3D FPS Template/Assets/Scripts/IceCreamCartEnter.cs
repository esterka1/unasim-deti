using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IceCreamCartEnter : MonoBehaviour
{
    [Header("UI")]
    public GameObject pressEText;

    [Header("Scene")]
    public string cookingSceneName = "IceCreamCooking";

    private bool playerNear = false;

    void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Dite1Dialog.dite1ObjednavkaPrijata && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(cookingSceneName);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Dite1Dialog.dite1ObjednavkaPrijata)
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