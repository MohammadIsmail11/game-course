using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroyer : MonoBehaviour
{
    // This method is called when the collider enters another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Destroyable"
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            // Destroy the object that was collided with
            Destroy(collision.gameObject);
        }
    }
}
