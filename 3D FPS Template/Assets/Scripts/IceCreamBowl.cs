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
    }

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

        IceCreamData.addedIngredients = new List<string>(addedIngredients);

        if (addIngredientEffect != null)
        {
            addIngredientEffect.Play();
        }

        Debug.Log("Přidaná ingredience do zmrzliny: " + ingredient.ingredientName);

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