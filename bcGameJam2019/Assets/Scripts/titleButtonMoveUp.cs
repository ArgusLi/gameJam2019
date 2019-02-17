using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleButtonMoveUp : MonoBehaviour
{
    public float shipscrollspeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, shipscrollspeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y == -16f)
        {
            rb.velocity = new Vector2(0,0);
        }
    }
}
