using System.Collections;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject[] gunPrefabs;
    public KeyCode switchKey = KeyCode.E; // Default key to switch weapons
    public GameObject gunHolder; // Reference to the object where guns will be spawned
    public float cooldownTime = 1.5f; // Cooldown time after switching weapons

    private GunBehavior currentGun;
    private int currentGunIndex = 0;
    private bool canSwitch = true; // Boolean to check if weapon switching is allowed
    private bool canShoot = true;  // Boolean to check if shooting is allowed

    

    private void Start()
    {
        EquipGun();
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey) && canSwitch)
        {
            StartCoroutine(SwitchGunWithCooldown());
        }
    }

    public void EquipGun()
    {
        if (gunPrefabs.Length > 0 && gunHolder != null)
        {
            if (currentGun != null)
            {
                Destroy(currentGun.gameObject);
            }
            GameObject newGun = Instantiate(gunPrefabs[currentGunIndex], gunHolder.transform);
            currentGun = newGun.GetComponent<GunBehavior>();
        }
        else
        {
            Debug.LogError("Gun prefabs or gun holder is not assigned.");
        }
    }

    private IEnumerator SwitchGunWithCooldown()
    {
        canSwitch = false;
        canShoot = false; // Disable shooting during cooldown
        SwitchGun();
        yield return new WaitForSeconds(cooldownTime);
        canSwitch = true;
        canShoot = true; // Re-enable shooting after cooldown
    }

    public void SwitchGun()
    {
        if (currentGun != null)
        {
            Destroy(currentGun.gameObject);
        }

        currentGunIndex = (currentGunIndex + 1) % gunPrefabs.Length;
        GameObject newGun = Instantiate(gunPrefabs[currentGunIndex], gunHolder.transform);
        currentGun = newGun.GetComponent<GunBehavior>();
    }

    public void Shoot()
    {
        if (currentGun != null && canShoot) // Check if shooting is allowed
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(-transform.up * currentGun.Shoot(), ForceMode2D.Impulse);
        }
    }
}
