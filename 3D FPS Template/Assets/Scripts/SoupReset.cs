using Unity.VisualScripting;
using UnityEngine;

public class SoupReset : MonoBehaviour
{
   
   public void Start()
    {
           SoupData.addedIngredients.Clear();
           Debug.Log("SoupData Cleared");
    }


}
