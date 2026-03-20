using System;
using Core;
using TMPro;
using UnityEngine;

public class Dialogue : Interactable
{
    public string dialogueText = "Hello, this is a dialogue.";
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Show dialogue when interaction starts
    public override void Interact(Collider other)
    {
        base.Interact(other);
        Interface.Instance.ShowDialogue(dialogueText);
        if (animator != null) animator.SetBool("talk", true);
    }

    // Clear dialogue when interaction stops
    public override void StopInteraction(Collider other)
    {
        base.StopInteraction(other);
        Interface.Instance.HideDialogue();
        if (animator != null) animator.SetBool("talk", false);

    }
}
