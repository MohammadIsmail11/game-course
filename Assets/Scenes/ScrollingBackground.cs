using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Speed of the scrolling
    private Renderer rend;

    void Start()
    {
        // Get the Renderer component
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Adjust the material's offset for reverse scrolling
        float offset = Time.time * -scrollSpeed; // Negate the scrollSpeed for opposite direction
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
