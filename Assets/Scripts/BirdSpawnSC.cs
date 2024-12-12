using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnSC : MonoBehaviour
{
    public GameObject Bird;            // The bird prefab
    public float maxSpawnRate = 5f;    // Maximum spawn interval
    public float spawnRadius = 0.5f;   // Radius to check for empty space
    public LayerMask obstacleLayer;    // Layer mask for detecting obstacles
    public float topGap = 0.5f;        // Gap from the top of the viewport

    void Start()
    {
        Invoke("spawnBird", maxSpawnRate);
        InvokeRepeating("increaseInSpawning", 0f, 30f);
    }

    void spawnBird()
    {
        // Get the min and max points of the viewport
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        int maxAttempts = 10; // Maximum attempts to find an empty space
        bool spawned = false;

        for (int i = 0; i < maxAttempts; i++)
        {
            // Generate a random X position along the top of the viewport with a gap
            Vector2 spawnPosition = new Vector2(Random.Range(min.x, max.x), max.y - topGap);

            // Check if the position is empty using OverlapCircle
            if (!Physics2D.OverlapCircle(spawnPosition, spawnRadius, obstacleLayer))
            {
                // Position is empty, spawn the bird
                GameObject aBird = Instantiate(Bird);
                aBird.transform.position = spawnPosition;

                spawned = true;
                break;
            }
        }

        // If no empty space is found, skip this spawn cycle
        if (spawned)
        {
            scheduleNextSpawn();
        }
    }

    void scheduleNextSpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRate > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRate);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("spawnBird", spawnInSeconds);
    }

    void increaseInSpawning()
    {
        if (maxSpawnRate > 1f)
            maxSpawnRate--;

        if (maxSpawnRate < 1f)
            CancelInvoke("increaseInSpawning");
    }
}
