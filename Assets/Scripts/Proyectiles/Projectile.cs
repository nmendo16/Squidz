using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 5f; // Time before the projectile is destroyed

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Example interaction: log collision details for debugging
        //Debug.Log("Projectile collided with: " + collision.gameObject.name);

        // Additional logic for interactions can be added here

        // Destroy the projectile on collision
        Destroy(gameObject);
    }
}
