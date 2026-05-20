using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float distance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            Child child = hit.collider.GetComponent<Child>();
            if (child != null)
            {
                if (!GameManager.instance.questActive)
                    child.Interact();
                else
                    child.Deliver();

                return;
            }

            Toy toy = hit.collider.GetComponent<Toy>();
            if (toy != null)
            {
                GameManager.instance.RegisterToy(toy);
                return;
            }
        }
    }
}
