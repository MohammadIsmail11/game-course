using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y = pos.y + speed * Time.deltaTime;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        transform.position = pos;

        if (transform.position.y > max.y)
            Destroy(gameObject);
    }
}
