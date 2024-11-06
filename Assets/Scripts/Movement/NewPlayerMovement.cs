using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float hp = 100f;
    [SerializeField] private bool isPlayer2 = false;

    private Rigidbody2D rb;
    private GunManager gunManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gunManager = GetComponent<GunManager>();

        // Check if GunManager is assigned properly
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
            rb.velocity = rb.velocity * 0.98f;
        }
    }

    void HandleRotation()
    {
        float horizontalInput = isPlayer2 ? Input.GetAxis("Horizontal2") : Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed * Time.deltaTime);
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
}
