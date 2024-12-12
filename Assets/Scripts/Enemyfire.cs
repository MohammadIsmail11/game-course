using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfire : MonoBehaviour
{
  
    public GameObject PlayerBullet;      // Bullet prefab
    public GameObject GunPoint;          // Firing point for bullets
    public float minFireInterval = 0.5f; // Minimum time between bullets
    public float maxFireInterval = 2f;   // Maximum time between bullets

    void Start()
    {
        

        // Start firing bullets automatically
        StartCoroutine(FireBulletsAutomatically());
    }

    void Update()
    {
        
    }

    IEnumerator FireBulletsAutomatically()
    {
        while (true)
        {
            // Wait for a random interval between minFireInterval and maxFireInterval
            float waitTime = Random.Range(minFireInterval, maxFireInterval);
            yield return new WaitForSeconds(waitTime);

            // Instantiate a bullet at the GunPoint's position
            GameObject bullet = Instantiate(PlayerBullet);
            bullet.transform.position = GunPoint.transform.position;

            // Optional: Add sound or animation for the firing effect
        }
    }
}
