using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 movement;

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector2 direction = movement.normalized * speed;
        transform.Translate(direction * Time.fixedDeltaTime);
    }
}
