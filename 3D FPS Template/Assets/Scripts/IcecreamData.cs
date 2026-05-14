using System.Collections.Generic;

public static class IceCreamData
{
    public static List<string> addedIngredients = new List<string>();

    public static void Clear()
    {
        addedIngredients.Clear();
    }

    public static void AddIngredient(string ingredient)
    {
        addedIngredients.Add(ingredient);
    }
}