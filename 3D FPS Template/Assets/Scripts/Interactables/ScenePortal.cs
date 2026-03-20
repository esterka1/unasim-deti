using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : Interactable
{
    [Tooltip("Add a name of the Scene you want to move to, the scene also must be in the Build List!")]
    [SerializeField] private string sceneName;

    public void Awake()
    {
        var scene = SceneManager.GetSceneByName(sceneName);
        if (scene.IsValid())
            Debug.LogWarning($"The Scene {sceneName} does not exist!");
    }

    public override void Interact(Collider other)
    {
        base.Interact(other);
        SceneManager.LoadScene(sceneName);
    }
}
