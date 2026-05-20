using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerSpawnUnos : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("PlayerSpawnUnos zapnutý.");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Načtená scéna: " + scene.name);

        if (scene.name == "unos1")
        {
            StartCoroutine(SpawnAfterLoad());
        }
    }

    IEnumerator SpawnAfterLoad()
    {
        yield return null;
        yield return null;

        if (PlayerPrefs.GetInt("ReturnFromIceCream", 0) != 1)
        {
            Debug.Log("ReturnFromIceCream není 1.");
            yield break;
        }

        GameObject spawn = GameObject.Find("IceCreamReturnSpawn");

        if (spawn == null)
        {
            Debug.LogError("Nenašel jsem IceCreamReturnSpawn ve scéně.");
            yield break;
        }

        CharacterController cc = GetComponentInChildren<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        transform.position = spawn.transform.position;

        if (cc != null)
            cc.enabled = true;

        PlayerPrefs.SetInt("ReturnFromIceCream", 0);
        PlayerPrefs.Save();

        Debug.Log("Spawn před vozíkem hotový.");
    }
}