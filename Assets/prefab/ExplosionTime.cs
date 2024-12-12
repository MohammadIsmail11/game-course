using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTime : MonoBehaviour
{
    public float delay = 0.5f; // adjust the delay based on explosion length

    void Start()
    {
        Destroy(gameObject, delay); // Destroys the explosion object after the delay
    }
}