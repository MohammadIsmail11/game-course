using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float speed; // Bullet speed

    void Start()
    {
        speed = 3f; // Adjust speed as needed
    }

    void Update()
    {
        Vector2 pos = transform.position;

        // Move the bullet downward
        pos.y = pos.y - speed * Time.deltaTime;

        // Update the bullet's position
        transform.position = pos;

        // Destroy the bullet if it goes below the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Bottom-left corner of the viewport
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    // Detect collision with the Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the bullet
            Destroy(gameObject);

            

            Debug.Log("Bullet hit the Player!");
        }
    }
}
