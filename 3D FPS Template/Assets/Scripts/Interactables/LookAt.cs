
using Unity.Cinemachine;
using UnityEngine;

public class LookAt :Interactable
{
  /*  [Tooltip("How long should we look? (in seconds)")]
    [SerializeField] private float duration = 5f; // in seconds
    [SerializeField] private CinemachineCamera camera;

    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        ShowCamera();
        
        // Invoke has a bit strange way of writing - you need to wrap the method name into nameof(MethodName) or just type it as string "MethodName"
        Invoke(nameof(HideCamera),duration);
    }

    // you can use => instead of { } for methods, that have just one line
    private void ShowCamera() => camera?.gameObject.SetActive(true);
    private void HideCamera() => camera?.gameObject.SetActive(false);
    

    public override void StopInteraction(Collider2D other)
    {
        base.StopInteraction(other);
        HideCamera();
    }*/
}
