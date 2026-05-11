using System.Collections;
using UnityEngine;
using TMPro;

public class InnerMonologue : MonoBehaviour
{
    public GameObject textObject;
    public float showTime = 4f;

    IEnumerator Start()
    {
        textObject.SetActive(true);

        yield return new WaitForSeconds(showTime);

        textObject.SetActive(false);
    }
}