using UnityEngine;
using System.Collections;

public class GunBehavior : MonoBehaviour
{
    public float damage = 10f;
    public float impulse = 5f;
    public float velocityMultiplier = 1.0f;
    public float bulletAcelleration = 1.0f;
    public float extraAcceleration = 5.0f; // Additional force to apply
    public float delayTime = 1.0f; // Time in seconds before applying extra force
    public float rateOfFire = 0.5f; // Time in seconds between shots (0.5s for 2 shots per second)
    private float lastShotTime; // Time when the last shot was fired

    public GameObject bullet;
    public Transform ShootingPoint;

    private void Start()
    {
        lastShotTime = -rateOfFire; // Allows shooting immediately at the start
    }

    public float Shoot()
    {
        // Check if enough time has passed since the last shot
        if (Time.time - lastShotTime >= rateOfFire)
        {
            lastShotTime = Time.time; // Update the last shot time

            GameObject bulletInstance = Instantiate(bullet, ShootingPoint.position, ShootingPoint.rotation);

            // Apply initial force to the bullet
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(ShootingPoint.up * velocityMultiplier, ForceMode2D.Impulse);

                // Check if acceleration is greater than 4.0f
                if (extraAcceleration > 4.0f)
                {
                    // Start a coroutine to add extra acceleration after a delay
                    StartCoroutine(AddExtraAcceleration(rb));
                }
            }

            // Logic for shooting, like playing sound effects or animations
            // Debug.Log("Gun fired with impulse: " + impulse);
            return impulse;
        }

        return 0f; // No shot fired due to cooldown
    }

    private IEnumerator AddExtraAcceleration(Rigidbody2D rb)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Apply additional force to the bullet
        if (rb != null)
        {
            rb.AddForce(ShootingPoint.up * extraAcceleration * 3, ForceMode2D.Impulse);
            Debug.Log("Extra acceleration applied: " + extraAcceleration);
        }
    }
}
