using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlenshipdiag : MonoBehaviour
{
    public float shipscrollspeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.5f * shipscrollspeed, shipscrollspeed);
    }
}
