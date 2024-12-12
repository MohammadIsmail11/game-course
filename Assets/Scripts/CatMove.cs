using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + speed * Time.deltaTime;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        transform.position = pos;
        
        if (transform.position.x > max.x)
            Destroy(gameObject);
    }
}