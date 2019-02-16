using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameShip : MonoBehaviour
{
    public Camera camera;
    public float shipMoveSpeed;
    public float shipScrollSpeed;

    private Rigidbody2D shipRB;
    private Rigidbody2D cameraRB;

    void Start()
    {
        shipRB = GetComponent<Rigidbody2D>();
        cameraRB = camera.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float vertextent = camera.orthographicSize;
        float horzextent = vertextent;
        float leftBound = camera.transform.position.x - horzextent;
        float rightBound = camera.transform.position.x + horzextent;
        float topBound = camera.transform.position.y + vertextent;
        float bottomBound = camera.transform.position.y - vertextent;

        Vector2 shipVelocity = new Vector2(
            Input.GetAxisRaw("Horizontal")*shipMoveSpeed,
            Input.GetAxisRaw("Vertical")*shipMoveSpeed + shipScrollSpeed);


        Vector2 newpos = shipRB.position + shipVelocity * Time.fixedDeltaTime;
        if (newpos.y >= topBound)
        {
            newpos.y = topBound;
        }
        else if(newpos.y <= bottomBound)
        {
            newpos.y = bottomBound;
        }
        if (newpos.x > rightBound)
        {
            newpos.x = rightBound;
        }
        else if (newpos.x < leftBound)
        {
            newpos.x = leftBound;
        }

        shipRB.MovePosition(newpos);
        
        if (newpos.y > 100) {
            shipRB.MovePosition(new Vector2(shipRB.position.x, 0));
            cameraRB.MovePosition(new Vector2(cameraRB.position.x, 0));
        }
    }


}
