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
        if (playerNear && IceCreamData.dite1Talked && Input.GetKeyDown(KeyCode.E))
        {
            IceCreamData.delalIcecream = true;
            SceneManager.LoadScene(cookingSceneName);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IceCreamData.dite1Talked)
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