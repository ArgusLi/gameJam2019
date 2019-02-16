using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -5);
        if (rb.position.y < -100) {
            rb.MovePosition(Vector2.zero);
        }
    }
}
