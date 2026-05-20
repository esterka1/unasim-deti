using System.Collections.Generic;

public static class IceCreamData1
{
    public static List<string> addedIngredients = new List<string>();

    public static bool dite1UzMluvilo = false;

    public static void Clear()
    {
        addedIngredients.Clear();
    }

    public static void AddIngredient(string ingredient)
    {
        addedIngredients.Add(ingredient);
    }
}