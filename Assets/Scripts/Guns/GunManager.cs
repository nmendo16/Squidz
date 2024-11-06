using System.Collections;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject[] gunPrefabs;
    public KeyCode switchKey = KeyCode.E; // Default key to switch weapons

    private GunBehavior currentGun;
    private int currentGunIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            SwitchGun();
        }
    }

    public void EquipGun()
    {
        if (gunPrefabs.Length > 0)
        {
            GameObject initialGun = Instantiate(gunPrefabs[currentGunIndex], transform);
            currentGun = initialGun.GetComponent<GunBehavior>();
        }
    }

    public void SwitchGun()
    {
        if (currentGun != null)
        {
            Destroy(currentGun.gameObject);
        }

        currentGunIndex = (currentGunIndex + 1) % gunPrefabs.Length;
        GameObject newGun = Instantiate(gunPrefabs[currentGunIndex], transform);
        currentGun = newGun.GetComponent<GunBehavior>();
    }

    public void Shoot()
    {
        if (currentGun != null)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(-transform.up * currentGun.Shoot(), ForceMode2D.Impulse);
        }
    }
}
