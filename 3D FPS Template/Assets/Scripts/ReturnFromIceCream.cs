using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromIceCream : MonoBehaviour
{
    public string returnSceneName = "unos1";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC zmáčknuto, vracím se ze zmrzliny.");

            PlayerPrefs.SetInt("ReturnFromIceCream", 1);
            PlayerPrefs.Save();

            Debug.Log("ReturnFromIceCream nastaveno na: " + PlayerPrefs.GetInt("ReturnFromIceCream"));

            SceneManager.LoadScene(returnSceneName);
        }
    }
}