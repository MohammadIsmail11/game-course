using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyable") // Ensure the other box has this tag
        {
            // Instantiate the explosion at the point of collision
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}