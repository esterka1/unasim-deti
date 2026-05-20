using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    public string currentHint;

    public Toy heldToy;

    public TMP_Text hintText;   // 👈 UI TEXT

    void Awake()
    {
        instance = this;
    }

    public void StartQuest()
    {
        if (state != GameState.GoToChild) return;

        string[] hints = { "small", "big" };
        currentHint = hints[Random.Range(0, hints.Length)];

        state = GameState.FindToy;

        ShowHint();
    }

    void ShowHint()
    {
        if (currentHint == "small")
            hintText.text = "Dítě chce: malou hračku ";
        else
            hintText.text = "Dítě chce: velkou hračku ";
    }

    public void PickToy(Toy toy)
    {
        if (state != GameState.FindToy) return;

        heldToy = toy;
        state = GameState.ReturnToChild;
    }

    public void DeliverToy()
    {
        if (state != GameState.ReturnToChild) return;

        if (heldToy != null && heldToy.Matches(currentHint))
            hintText.text = "✔ Správně!";
        else
            hintText.text = "❌ Špatně!";

        state = GameState.GoToChild;
        heldToy = null;
        currentHint = "";
    }
}
