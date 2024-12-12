using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Bird;           // The bird prefab
    public float maxSpawnRate = 5f;   // Maximum spawn interval
    public float topGap = 0.5f;       // Gap from the top of the viewport
    public float birdSpeed = 2f;      // Speed at which the bird moves downwards

    void Start()
    {
        // Start spawning birds
        Invoke("spawnBird", maxSpawnRate);
        InvokeRepeating("increaseInSpawning", 0f, 30f);
    }

    void spawnBird()
    {
        // Get the min and max points of the viewport
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Generate a random X position along the top of the viewport with a gap
        Vector2 spawnPosition = new Vector2(Random.Range(min.x, max.x), max.y - topGap);

        // Instantiate the bird
        GameObject aBird = Instantiate(Bird);
        aBird.transform.position = spawnPosition;

        // Add downward movement to the bird
        Rigidbody2D rb = aBird.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity
        rb.velocity = new Vector2(0, -birdSpeed); // Move downward

        // Destroy the bird when it goes out of the viewport
        Destroy(aBird, 10f); // Adjust the time as needed based on the viewport size

        scheduleNextSpawn();
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
