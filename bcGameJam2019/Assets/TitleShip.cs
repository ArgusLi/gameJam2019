using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShip : MonoBehaviour
{
    public float shipscrollspeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.5f * shipscrollspeed, shipscrollspeed);
    }
}
