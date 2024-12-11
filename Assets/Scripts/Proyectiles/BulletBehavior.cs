using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float maxSpeed = 10.0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Rotate the bullet to match its velocity direction
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }

        // Apply acceleration if below max speed
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(rb.velocity.normalized * acceleration * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}
