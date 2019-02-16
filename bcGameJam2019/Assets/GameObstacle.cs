﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObstacle : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject ship;
    public int numObstacles;
    
    private System.Random rand;
    private GameObject[] obstacles;
    private Rigidbody2D[] rbs;
    private Vector2[] positions;
    
    void ResetPosition(int i) {
        positions[i].x = ship.transform.position.x + rand.Next(5) - 2;
        positions[i].y = ship.transform.position.y + 10 + rand.Next(6);
        rbs[i].MovePosition(positions[i]);
    }
 
    void Start() {
        rand = new System.Random();
        obstacles = new GameObject[numObstacles];
        rbs = new Rigidbody2D[numObstacles];
        positions = new Vector2[numObstacles];
        for (int i = 0; i < numObstacles; i++) {
           GameObject obstacle = new GameObject("Obstacle" + i.ToString());
           SpriteRenderer renderer = obstacle.AddComponent<SpriteRenderer>();
           obstacle.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
           if (i % 2 == 0) {
                renderer.sprite = sprite1;
           } else {
                renderer.sprite = sprite2;
           }
           Rigidbody2D rb = obstacle.AddComponent<Rigidbody2D>();
           
           obstacles[i] = obstacle;
           rbs[i] = rb;
           positions[i] = Vector2.zero;
           ResetPosition(i);
        }
    }

    void Update()
    {
        for (int i = 0; i < numObstacles; i++) {
            rbs[i].velocity = new Vector2(0, 3);
            if (rbs[i].position.y < ship.transform.position.y - 10 + rand.Next(6)) {
                ResetPosition(i);
            } else if (rbs[i].position.y > ship.transform.position.y + 50) {
                ResetPosition(i);
            }
        }
    }
}
