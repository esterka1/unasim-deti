using TMPro;
using UnityEngine;

namespace Core
{
    public class Interface : MonoBehaviour
    {
        public TextMeshProUGUI dialogueUI;
        public TextMeshProUGUI scoreUI;
        public TextMeshProUGUI healthUI;
        public TextMeshProUGUI hintUI;
    
    
        // This is called Singleton Pattern, it makes it easy to call this object from other scripts (like GetComponent but for just this single object)
        public static Interface Instance;

        public void Awake()
        {
            Instance = this;
            if (Instance == null)
                Debug.LogWarning("There is no Interface script in the Scene, did you add the Core prefab into the Scene?");
        }

        // Function to show dialogue
        public void ShowDialogue(string dialogue)
        {
            // First check if dialogueUI is not null to avoid errors, if we forgot to assign it in the inspector nothing will happen
            // All other functions in this script do the same
            if (dialogueUI != null) 
                dialogueUI.text = dialogue;
        }

        // Function to show score
        public void ShowScore(int score)
        {
            if (scoreUI != null) scoreUI.text = score.ToString();
        }

        // Function to show hint text
        public void ShowHint(string hint)
        {
            if (hintUI != null) hintUI.text = hint;
        }

        // Function to hide hint text
        public void HideHint()
        {
            if (hintUI != null) hintUI.text = "";
        }

        // Function to show health
        public void ShowHealth(float currentHealth, float maxHealth)
        {
            if (healthUI != null) healthUI.text = $"Health : {currentHealth}/{maxHealth}";
        }

        public void HideDialogue()
        {
            if (dialogueUI != null) dialogueUI.text = "";
        }
    }
}
