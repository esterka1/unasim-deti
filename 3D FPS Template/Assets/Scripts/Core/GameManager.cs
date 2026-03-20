using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
    
        // This is called Singleton Pattern, it makes it easy to call this object from other scripts (like GetComponent but for just this single object)
        public static GameManager Instance;

        public void Awake()
        {
            Instance = this;
            if (Instance == null)
                Debug.LogWarning("There is no Interface script in the Scene, did you add the Core prefab into the Scene?");
        }
    
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    
    
    
    
    }
}
