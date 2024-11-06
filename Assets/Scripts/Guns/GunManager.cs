using System.Collections;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject[] gunPrefabs;
    public KeyCode switchKey = KeyCode.E; // Default key to switch weapons
    public GameObject gunHolder; // Reference to the object where guns will be spawned

    private GunBehavior currentGun;
    private int currentGunIndex = 0;

    private void Start()
    {
        EquipGun();
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            SwitchGun();
        }
    }

    public void EquipGun()
    {
        if (gunPrefabs.Length > 0 && gunHolder != null)
        {
            GameObject initialGun = Instantiate(gunPrefabs[currentGunIndex], gunHolder.transform);
            currentGun = initialGun.GetComponent<GunBehavior>();
        }
        else
        {
            Debug.LogError("Gun prefabs or gun holder is not assigned.");
        }
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
        if (currentGun != null)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(-transform.up * currentGun.Shoot(), ForceMode2D.Impulse);
        }
    }
}
