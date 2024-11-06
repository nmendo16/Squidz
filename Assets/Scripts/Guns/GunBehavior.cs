using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public float damage = 10f;
    public float impulse = 5f;
    public float velocityMultiplier = 1.0f;
    public float bulletAcelleration = 1.0f;
    public GameObject bullet;
    public Transform ShootingPoint;
 

    public float Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, ShootingPoint.position, ShootingPoint.rotation);

        //Apply force to the bullet

        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(ShootingPoint.up * velocityMultiplier, ForceMode2D.Impulse);
            if (bulletAcelleration > 1)
            {

            }
        }

        // Logic for shooting, like playing sound effects or animations
        Debug.Log("Gun fired with impulse: " + impulse);
        return impulse;
    }
}
