using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public float damage = 10f;
    public float impulse = 5f;

    public float Shoot()
    {
        // Logic for shooting, like playing sound effects or animations
        Debug.Log("Gun fired with impulse: " + impulse);
        return impulse;
    }
}
