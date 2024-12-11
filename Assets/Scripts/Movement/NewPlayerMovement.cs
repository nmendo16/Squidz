using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float hp = 100f;
    [SerializeField] private bool isPlayer2 = false;

    [SerializeField]
    private Animator animator;
    private Rigidbody2D rb;
    private GunManager gunManager;
    public Collider2D arenaCollider;// add the arena bouds collider
    public float bounceLearp = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gunManager = GetComponent<GunManager>();

        if (gunManager == null)
        {
            Debug.LogError("GunManager component is missing on " + gameObject.name);
        }
        else
        {
            gunManager.EquipGun(); // Equip the gun once during start
        }
    }

    void FixedUpdate()
    {
        HandleRotation();
        animator.SetFloat("velocity", rb.velocity.magnitude);

        if (!isPlayer2)
        {
            if (Input.GetKey(KeyCode.S))
            {
                gunManager.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                gunManager.SwitchGun();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.L))
            {
                gunManager.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                gunManager.SwitchGun();
            }
        }

        // Decelerate when moving
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity *= 0.90f;
        }

        if (arenaCollider != null && !arenaCollider.bounds.Contains((Vector2)transform.position))
        {
            // Calculate the nearest point on the collider bounds and set the player’s position to that point
            Vector2 closestPoint = arenaCollider.ClosestPoint(transform.position);
            transform.position = Vector2.Lerp(transform.position, closestPoint, Time.deltaTime * bounceLearp);


            // Optional: Set velocity to zero to prevent further movement out of bounds
            rb.velocity = Vector2.zero;
        }

    }

    void HandleRotation()
    {
        float horizontalInput = isPlayer2 ? Input.GetAxis("Horizontal2") : Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            rb.rotation += -horizontalInput * rotationSpeed * Time.deltaTime;
        }
    }

    public void OnHit(float damage)
    {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool GetPlayerNumber()
    {
        return isPlayer2;
    }

}
