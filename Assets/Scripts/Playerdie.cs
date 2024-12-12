using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdie : MonoBehaviour
{
    // This method is called when the collider enters another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce the player's lives using PlayerLivesManager
            if (PlayerLivesManager.instance != null)
            {
                PlayerLivesManager.instance.ReduceLife();
            }
        }
    }
}
