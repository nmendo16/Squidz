using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTPlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<TESTBullet>().shooter = gameObject;
    }
}
