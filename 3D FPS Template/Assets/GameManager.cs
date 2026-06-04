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
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nI want a small toy.";
        }
        else
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nI want a big toy.";
        }
    }
public void PickToy(Toy toy)
{
    if (state != GameState.FindToy)
        return;

    heldToy = toy;

    state = GameState.ReturnToChild;

    hintText.text = "I found a toy. I should bring it back to her.";

    toy.gameObject.SetActive(false);
}

    public void DeliverToy()
    {
        if (state != GameState.ReturnToChild)
            return;

        if (heldToy != null && heldToy.Matches(currentHint))
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nThat's it!";
        }
        else
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nThat's not  what I wanted..";
        }
    }
}
