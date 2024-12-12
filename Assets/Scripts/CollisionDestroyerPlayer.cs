using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroyerPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Destroyable"
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            // Destroy the enemy
            Destroy(collision.gameObject);

            // Increase the score by 5 using the ScoreManager
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(5);
            }
        }
    }
}
