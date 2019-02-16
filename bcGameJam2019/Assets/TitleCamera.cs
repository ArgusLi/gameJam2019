using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    public float shipscrollspeed;
    private Rigidbody2D rb;

    public float zoomSpeed;
    public float targetOrtho;
    public float smoothSpeed;
    public float minOrtho;
    public float maxOrtho;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.5f*shipscrollspeed, shipscrollspeed);
    }

    void Update()
    {
        targetOrtho += zoomSpeed;
        targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}


