using UnityEngine;

using System.Collections.Generic;

public class Soup : MonoBehaviour
{
    public List<string> requiredIngredients = new List<string>();
    public List<string> addedIngredients = new List<string>();

    public int maxIngredients = 3;
    public ParticleSystem addIngredientEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("food"))
            return;

        Ingredient ingredient = other.GetComponent<Ingredient>();

        if (ingredient == null)
            return;

        if (addedIngredients.Count >= maxIngredients)
            return;

        addedIngredients.Add(ingredient.ingredientName);

        if (addIngredientEffect != null)
        {
            addIngredientEffect.Play();
        }

        Destroy(other.gameObject);
    }

    public bool IsCorrectSoup()
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