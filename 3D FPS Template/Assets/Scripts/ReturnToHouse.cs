using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHouse : MonoBehaviour
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