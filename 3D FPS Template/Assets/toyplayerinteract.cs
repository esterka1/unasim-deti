using UnityEngine;

public class ToyPlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float distance = 5f;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E ZMACKNUTO");
            Interact();
        }
    }

    void Interact()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log("Trefil jsem: " + hit.collider.name);

            Child child = hit.collider.GetComponentInParent<Child>();
            if (child != null)
            {
                child.Interact();
                return;
            }

            Toy toy = hit.collider.GetComponentInParent<Toy>();
            if (toy != null)
            {
                GameManager.instance.PickToy(toy);
                return;
            }
        }
        else
        {
            Debug.Log("Nic jsem netrefil");
        }
    }
}
