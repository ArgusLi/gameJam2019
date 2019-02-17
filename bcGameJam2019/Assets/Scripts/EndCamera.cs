﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamera : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -0.3f);
        if (rb.position.y < -100) {
            rb.MovePosition(Vector2.zero);
        }
    }
}
