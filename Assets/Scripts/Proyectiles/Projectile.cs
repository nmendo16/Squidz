using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 5f; // Time before the projectile is destroyed
    public AudioClip destroySound;
    public AudioClip spawnSound;

    void Start()
    {
        AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position);
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Example interaction: log collision details for debugging
        //Debug.Log("Projectile collided with: " + collision.gameObject.name);
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        //destroySound.Play();

        //Deal damage if colliding with player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().OnHit(damage);
        }

        // Destroy the projectile on collision
        Destroy(gameObject);
    }
}
