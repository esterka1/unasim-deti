using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float range = 5f;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))
            {
                IngredientObject ing = hit.collider.GetComponent<IngredientObject>();

                if (ing != null)
                {
                    ing.OnClick();
                }
            }
        }
    }
}
