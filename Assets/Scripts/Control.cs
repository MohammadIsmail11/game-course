using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;
    public float maxY;
    public GameObject PlayerBullet;
    public GameObject GunPoint;
    public GameObject GunPoint1;

    void Start()
    {
        speed = 6f;
        maxY = 2f; // You can use this to set a specific upper boundary if needed.
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 pos = transform.position;

        // Update position based on input
        pos.x += moveX * speed * Time.deltaTime;
        pos.y += moveY * speed * Time.deltaTime;

        // Clamp the position to the viewport
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Top-right corner

        // Clamp x and y positions
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = GunPoint.transform.position;
        }

        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = GunPoint1.transform.position;
        }
    }
}