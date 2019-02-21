using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class GameShip : MonoBehaviour
{
    public Camera cam;
    public float shipMoveSpeed;
    public float shipScrollSpeed;
    public World world;
    public God god;

    //private PowerUps powerUps;
    private Rigidbody2D shipRB;
    private Rigidbody2D cameraRB;
    private Animator animator;
    private float startTime; // initial time in seconds
    private float endTime; //final time in seconds
    public float deltaTime; //score in seconds
    private float xaxis;
    private float yaxis;

    void Start()
    {
        transform.localPosition = new Vector3(0,0,0);

        startTime = Time.unscaledTime;

        shipRB = GetComponent<Rigidbody2D>();
        cameraRB = cam.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        float vertextent = cam.orthographicSize;
        float horzextent = vertextent;
        if(Math.Abs(cameraRB.rotation - 90f) < 0.1f) {
            
        }
        float leftBound = cam.transform.position.x - horzextent;
        float rightBound = cam.transform.position.x + horzextent;
        float topBound = cam.transform.position.y + vertextent;
        float bottomBound = cam.transform.position.y - vertextent;

        xaxis = Input.GetAxisRaw("Horizontal") * shipMoveSpeed;
        yaxis = Input.GetAxisRaw("Vertical") * shipMoveSpeed + shipScrollSpeed;
        Vector2 shipVelocity = new Vector2(xaxis,yaxis);


        Vector2 newpos = shipRB.position + shipVelocity * Time.fixedDeltaTime;
        if ((newpos.y >= topBound)||(newpos.y <= bottomBound)||(newpos.x > rightBound)||(newpos.x < leftBound))
        {
            //crash();
        }

        shipRB.MovePosition(newpos);
    }

    void crash(){
        if(Constants.getEnergy() == true)
        endTime = Time.unscaledTime;
        animator.SetBool("isTriggered", true);
        deltaTime = endTime - startTime;
        god.crash(deltaTime, this);
        Constants.setEnergy(true);
        this.transform.position = new Vector3(999, 999, 0);
    }

    public void respawn(){
        startTime = Time.unscaledTime;
        this.transform.position = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if (col.CompareTag("obstacle"))
        // {
        //     crash();
        // }
        // else if(col.CompareTag("spin"))
        // {  
        //     world.Rotate();
        // }
        // else if (col.CompareTag("sync4"))
        // {
        //     world.Sync();
        // }
        // else if (col.CompareTag("slow"))
        // {
        //     world.Slow();
        // }
        // else if (col.CompareTag("boost"))
        // {
        //     world.Boost();
        // }

    }

    
}
