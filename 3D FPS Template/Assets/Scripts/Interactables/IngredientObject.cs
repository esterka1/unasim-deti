using UnityEngine;

public class IngredientObject : MonoBehaviour
{
    public Ingredient data;
    public Transform potTarget;
    public float speed = 5f;

    private bool moving = false;

    public void OnClick()
    {
        FindObjectOfType<CookingSystem>().AddIngredient(data);
        moving = true;
    }

    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, potTarget.position, Time.deltaTime * speed);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, potTarget.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
