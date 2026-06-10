using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;
    public string currentHint;
    public Toy heldToy;

    public TMP_Text hintText;
    public TMP_Text questText;
    public TMP_Text endingText;

    public Image fadePanel;
    public string nextSceneName = "vByte";

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = GameState.GoToChild;

        hintText.text = "";
        endingText.text = "";
        questText.text = "<color=yellow><b>ÚKOL</b></color>\nPromluv si s dítětem.";

        Color c = fadePanel.color;
        c.a = 0f;
        fadePanel.color = c;
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
            hintText.text = "<color=#FF69B4><b>HOLČIČKA:</b></color>\nChtěla bych malou hračku.";

            questText.text =
                "<color=yellow><b>ÚKOL</b></color>\nNajdi malou hračku.";
        }
        else
        {
            hintText.text = "<color=#FF69B4><b>HOLČIČKA:</b></color>\nChtěla bych velkou hračku.";

            questText.text =
                "<color=yellow><b>ÚKOL</b></color>\nNajdi velkou hračku.";
        }

        StartCoroutine(ShowInnerMonologue());
    }

    IEnumerator ShowInnerMonologue()
    {
        yield return new WaitForSeconds(3f);

        hintText.color = Color.white;

        if (currentHint == "small")
            hintText.text = "<i>Chce něco malého... Měl bych se porozhlédnout.</i>";
        else
            hintText.text = "<i>Chce větší hračku... Musím nějakou najít.</i>";

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

            text.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha);

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
        hintText.text = "<i>Našel jsem hračku. Měl bych ji donést zpátky holčičce.</i>";

        questText.text =
            "<color=yellow><b>ÚKOL</b></color>\nVrať se za dítětem.";

        StartCoroutine(FadeOutText(hintText, 2f));

        toy.gameObject.SetActive(false);
    }

    public void DeliverToy()
    {
        if (state != GameState.ReturnToChild)
            return;

        hintText.color = Color.white;

        if (heldToy != null && heldToy.Matches(currentHint))
        {
            questText.text = "";
            StartCoroutine(SuccessEnding());
        }
        else
        {
            hintText.text =
                "<color=#FF69B4><b>HOLČIČKA:</b></color>\nTo není to, co jsem chtěla...";

            questText.text =
                "<color=yellow><b>ÚKOL</b></color>\nŽádná odměna.";
        }
    }

    IEnumerator SuccessEnding()
    {
        hintText.text =
            "<color=#FF69B4><b>HOLČIČKA:</b></color>\nAno, přesně takovou jsem chtěla!";

        yield return new WaitForSeconds(2f);

        hintText.text =
            "<i>Dobře... Teď mi důvěřuje.</i>";

        yield return new WaitForSeconds(3f);

        StartCoroutine(FadeOutText(hintText, 2f));

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(FadeToBlack(2f));

        endingText.text = "Šla za mnou bez jediného zaváhání.";
        yield return new WaitForSeconds(3f);

        endingText.text = "Práce byla dokončena.";
        yield return new WaitForSeconds(3f);

        endingText.text = "Dostal jsem zaplaceno.";
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeToBlack(float duration)
    {
        float time = 0f;

        Color color = fadePanel.color;
        color.a = 0f;
        fadePanel.color = color;

        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(0f, 1f, time / duration);
            fadePanel.color = color;

            yield return null;
        }

        color.a = 1f;
        fadePanel.color = color;
    }
}