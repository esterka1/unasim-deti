using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromCooking : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetString("SpawnPoint", "Kitchen");
            SceneManager.LoadScene("VByte");
        }
    }
}