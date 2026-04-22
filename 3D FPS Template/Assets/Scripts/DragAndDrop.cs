using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
         Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    newPos.z = transform.position.z;
    transform.position = newPos;
    }
}