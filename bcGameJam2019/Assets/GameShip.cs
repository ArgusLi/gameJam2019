using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class GameShip : MonoBehaviour
{
    public Camera cam;
    public float shipMoveSpeed;
    public float shipScrollSpeed;

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
        startTime = Time.unscaledTime;

        shipRB = GetComponent<Rigidbody2D>();
        cameraRB = cam.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        xaxis = Input.GetAxisRaw("Horizontal") * shipMoveSpeed;
        yaxis = Input.GetAxisRaw("Vertical") * shipMoveSpeed + shipScrollSpeed;
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

        Vector2 shipVelocity = new Vector2(xaxis,yaxis);


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



    void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.name == "obstacle")
        {
            endTime = Time.unscaledTime;
            animator.SetBool("isTriggered", true);
            deltaTime = endTime - startTime;
            StartCoroutine(LoadAfterDelay());
        }
        else if(col.name == "spin")
        {*/
        int direction = -1;//powerUps.spin();  //  if direction is clockwise then -1, if anticlockwise then 1
        xaxis = Input.GetAxisRaw("Vertical") * shipMoveSpeed * direction;
        yaxis = Input.GetAxisRaw("Horizontal") * shipMoveSpeed + shipScrollSpeed * direction;
        Vector3 rotateValue = new Vector3(0, -90, 0);
        shipRB.transform.eulerAngles = transform.eulerAngles - rotateValue;
        // cameraRB.transform.eulerAngles = transform.eulerAngles - rotateValue; 
        cameraRB.rotation += 90f;
        //}
        /*else if (col.name == "swap")
        {

        }
        else if (col.name == "sync2")
        {

        }
        else if (col.name == "sync4")
        {

        }
        else if (col.name == "slow")
        {

        }
        else if (col.name == "boost")
        {

        }*/

    }

    IEnumerator LoadAfterDelay() {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("score", deltaTime);
    }
}
