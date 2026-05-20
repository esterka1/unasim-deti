using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    public string currentHint;

    public Toy heldToy;

    public TMP_Text hintText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = GameState.GoToChild;

        hintText.text = "";
    }

    public void StartQuest()
    {
        if (state != GameState.GoToChild)
            return;

        string[] hints = { "small", "big" };

        currentHint = hints[Random.Range(0, hints.Length)];

        state = GameState.FindToy;

        ShowHint();
    }

    void ShowHint()
    {
        if (currentHint == "small")
        {
            hintText.text = "Chci malou hračku...";
        }
        else
        {
            hintText.text = "Chci velkou hračku...";
        }
    }

    public void PickToy(Toy toy)
    {
        if (state != GameState.FindToy)
            return;

        heldToy = toy;

        state = GameState.ReturnToChild;

        hintText.text = "Vrať se za dítětem";
    }

    public void DeliverToy()
    {
        if (state != GameState.ReturnToChild)
            return;

        if (heldToy != null && heldToy.Matches(currentHint))
        {
            hintText.text = "To je ono!";
        }
        else
        {
            hintText.text = "To není ono...";
        }
    }
}
