using UnityEngine;

public class Toy : MonoBehaviour
{
    public string tagType; // např. "red", "blue", "soft"

    public bool Matches(string hint)
    {
        return tagType == hint;
    }
}
