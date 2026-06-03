using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowAfterSoup : MonoBehaviour
{
    public static FlowAfterSoup instance;

    public GameObject phoneMonologue;
    public GameObject phonePromptText;
    public GameObject phoneCallCanvas;
    public GameObject phoneObject;

    private bool phoneActive = false;
    private bool playerNearPhone = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        phoneMonologue.SetActive(false);
        phonePromptText.SetActive(false);
        phoneCallCanvas.SetActive(false);
        phoneObject.SetActive(false);
    }

    void Update()
    {
        if (phoneActive && playerNearPhone && Input.GetKeyDown(KeyCode.E))
        {
            PickUpPhone();
        }
    }

    public void AfterCorrectFood()
    {
        Invoke(nameof(ShowPhoneMonologue), 2f);
    }

    void ShowPhoneMonologue()
    {
        phoneMonologue.SetActive(true);

        phoneObject.SetActive(true);
        phoneActive = true;

        Invoke(nameof(HidePhoneMonologue), 4f);
    }

    void HidePhoneMonologue()
    {
        phoneMonologue.SetActive(false);
    }

    void PickUpPhone()
    {
        phonePromptText.SetActive(false);
        phoneCallCanvas.SetActive(true);

        Invoke(nameof(GoToKidnapScene), 6f);
    }

    void GoToKidnapScene()
    {
        SceneManager.LoadScene("unos1");
    }

    public void PlayerEnteredPhone()
    {
        if (!phoneActive) return;

        playerNearPhone = true;
        phonePromptText.SetActive(true);
    }

    public void PlayerLeftPhone()
    {
        playerNearPhone = false;
        phonePromptText.SetActive(false);
    }
}