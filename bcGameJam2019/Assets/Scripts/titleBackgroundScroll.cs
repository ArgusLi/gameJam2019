using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleBackgroundScroll : MonoBehaviour
{
    public float scrollSheet;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-0.3f * scrollSheet, -scrollSheet);
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.position.x < -40)
        {
            rb.MovePosition(Vector2.zero);
        }
    }
}
