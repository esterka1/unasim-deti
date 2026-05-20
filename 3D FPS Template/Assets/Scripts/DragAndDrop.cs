using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    private Camera cam;

   private void Awake()
    {
        cam = Camera.main;

        if (cam == null)
            cam = GameObject.Find("MainCamera")?.GetComponent<Camera>();
    }

    private Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
         Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    newPos.z = transform.position.z;
    transform.position = newPos;
    }
}