using UnityEngine;
using System.Collections.Generic;

public class IceCreamBowl : MonoBehaviour
{
    public List<string> requiredIngredients = new List<string>();
    public List<string> addedIngredients = new List<string>();

    public int maxIngredients = 2;

    public ParticleSystem addIngredientEffect;

    private void Start()
    {
        IceCreamData.addedIngredients.Clear();
        addedIngredients.Clear();

        Debug.Log("IceCreamBowl ready.");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Něco se dotklo misky: " + other.name);

        if (!other.CompareTag("food"))
        {
            Debug.Log("Objekt nemá tag food: " + other.name);
            return;
        }

        Ingredient ingredient = other.GetComponent<Ingredient>();

        if (ingredient == null)
        {
            Debug.Log("Objekt nemá Ingredient script: " + other.name);
            return;
        }

        if (addedIngredients.Count >= maxIngredients)
        {
            Debug.Log("Miska už má maximum ingrediencí.");
            return;
        }

        addedIngredients.Add(ingredient.ingredientName);
        IceCreamData.addedIngredients = new List<string>(addedIngredients);

        Debug.Log("PŘIDÁNO DO ZMRZLINY: " + ingredient.ingredientName);
        Debug.Log("Počet ingrediencí: " + addedIngredients.Count);

        if (addIngredientEffect != null)
        {
            addIngredientEffect.Play();
        }

        Destroy(other.gameObject);
    }

    public bool IsCorrectIceCream()
    {
        if (addedIngredients.Count != requiredIngredients.Count)
            return false;

        foreach (string ingredient in requiredIngredients)
        {
            if (!addedIngredients.Contains(ingredient))
                return false;
        }

        foreach (string ingredient in addedIngredients)
        {
            if (!requiredIngredients.Contains(ingredient))
                return false;
        }

        return true;
    }
}