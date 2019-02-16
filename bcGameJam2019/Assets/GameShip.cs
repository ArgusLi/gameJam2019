using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameShip : MonoBehaviour
{
    public float speed;
    public Camera thiscam;
    public float shipscrollspeed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float leftbound;
    private float topbound;
    private float bottombound;
    private float rightbound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // setting bounds for camera
        float vertextent = thiscam.orthographicSize;
        float horzextent = vertextent;
        leftbound = thiscam.transform.position.x - horzextent;
        rightbound = thiscam.transform.position.x + horzextent;
        topbound = thiscam.transform.position.y + vertextent;
        bottombound = thiscam.transform.position.y - vertextent;

        moveVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed + shipscrollspeed);


        Vector2 newpos = rb.position + moveVelocity * Time.fixedDeltaTime;
        if (newpos.y >= topbound)
        {
            newpos.y = topbound;
        }
        else if(newpos.y <= bottombound)
        {
            newpos.y = bottombound;
        }
        if (newpos.x > rightbound)
        {
            newpos.x = rightbound;
        }
        else if (newpos.x < leftbound)
        {
            newpos.x = leftbound;
        }

        rb.MovePosition(newpos);
    }


}
