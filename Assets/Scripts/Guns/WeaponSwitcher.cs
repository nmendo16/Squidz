using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // Array to hold the two weapon prefabs
    public KeyCode switchKey = KeyCode.Q; // Key to switch between weapons (default: 'Q')

    private GameObject currentWeapon; // Reference to the currently equipped weapon
    private int currentIndex = 0; // Index of the currently equipped weapon

    void Start()
    {
        // Equip the first weapon by default
        EquipWeapon(currentIndex);
    }

    void Update()
    {
        // Check if the switch key is pressed
        if (Input.GetKeyDown(switchKey))
        {
            // Toggle between weapon 0 and weapon 1
            currentIndex = 1 - currentIndex;
            EquipWeapon(currentIndex);
        }
    }

    // Method to equip a weapon based on the index
    void EquipWeapon(int index)
    {
        // If a weapon is already equipped, destroy it safely
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // Instantiate the new weapon prefab
        currentWeapon = Instantiate(weaponPrefabs[index], transform.position, transform.rotation);
        currentWeapon.transform.SetParent(transform); // Parent the weapon to the player
    }

    // Add a method to check if the current weapon is valid
    public bool IsCurrentWeaponValid()
    {
        return currentWeapon != null;
    }
}
