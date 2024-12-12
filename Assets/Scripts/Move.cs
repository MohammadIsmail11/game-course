using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private float direction = 1f; // 1 for right, -1 for left

    void Start()
    {
        speed = 3f;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += direction * speed * Time.deltaTime;

        // Get the right and left edges of the viewport
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Check for bounds and change direction if needed
        if (pos.x > max.x || pos.x < min.x)
        {
            direction *= -1; // Reverse direction
            Flip(); // Flip the object
        }

        transform.position = pos;
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the object on the x-axis
        transform.localScale = localScale;
    }
}