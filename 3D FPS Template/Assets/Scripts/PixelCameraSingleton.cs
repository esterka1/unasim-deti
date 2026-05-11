using UnityEngine;

public class PixelCameraSingleton : MonoBehaviour
{
    private static PixelCameraSingleton instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}