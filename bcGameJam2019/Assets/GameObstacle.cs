using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObstacle : MonoBehaviour
{
    public Sprite sprite;
    public GameObject ship;
    private GameObject obstacle;
    private Rigidbody2D rb;
    private Vector2 position;
    
    void ResetPosition() {
        position.x = ship.transform.position.x;
        position.y = ship.transform.position.y + 10;
        rb.MovePosition(position);
    }
 
    void Start() {
         obstacle = new GameObject("Obstacle");
         SpriteRenderer renderer = obstacle.AddComponent<SpriteRenderer>();
         obstacle.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
         renderer.sprite = sprite;
         rb = obstacle.AddComponent<Rigidbody2D>();
         ResetPosition();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, 3);
        if (rb.position.y < ship.transform.position.y - 10) {
            ResetPosition();
        }
    }
}
