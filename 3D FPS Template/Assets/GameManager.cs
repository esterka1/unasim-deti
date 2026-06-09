using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;
    public string currentHint;
    public Toy heldToy;
    public TMP_Text hintText;
    public TMP_Text questText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = GameState.GoToChild;

        hintText.text = "";
        questText.text = "<color=yellow><b>OBJECTIVE</b></color>\nTalk to the child";
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
        hintText.color = Color.white;

        if (currentHint == "small")
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nI want a small toy.";
            questText.text = "<color=yellow><b>OBJECTIVE</b></color>\nFind a small toy";
        }
        else
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nI want a big toy.";
            questText.text = "<color=yellow><b>OBJECTIVE</b></color>\nFind a big toy";
        }

        StartCoroutine(ShowInnerMonologue());
    }

    IEnumerator ShowInnerMonologue()
    {
        yield return new WaitForSeconds(3f);

        hintText.color = Color.white;

        if (currentHint == "small")
        {
            hintText.text = "<i>She wants something small. I should look around.</i>";
        }
        else
        {
            hintText.text = "<i>She wants a bigger toy. I should find one.</i>";
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(FadeOutText(hintText, 2f));
    }

    IEnumerator FadeOutText(TMP_Text text, float duration)
    {
        Color startColor = text.color;
        float time = 0f;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / duration);
            text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            time += Time.deltaTime;
            yield return null;
        }

        text.text = "";
        text.color = Color.white;
    }

    public void PickToy(Toy toy)
    {
        if (state != GameState.FindToy)
            return;

        heldToy = toy;
        state = GameState.ReturnToChild;

        hintText.color = Color.white;
        hintText.text = "<i>I found a toy. I should bring it back to her.</i>";

        questText.text = "<color=yellow><b>OBJECTIVE</b></color>\nBring it back to the child";

        toy.gameObject.SetActive(false);
    }

    public void DeliverToy()
    {
        if (state != GameState.ReturnToChild)
            return;

        hintText.color = Color.white;

        if (heldToy != null && heldToy.Matches(currentHint))
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nThat's it!";
            questText.text = "";
        }
        else
        {
            hintText.text = "<color=#FF69B4><b>GIRL:</b></color>\nThat's not what I wanted...";
        }
    }
}