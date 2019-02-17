using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Frame : MonoBehaviour
{

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject powerupTargets;
    public GameObject batteryTarget;

    private Rigidbody2D frameRB;
    private Rigidbody2D[] powerupBodies;
    private System.Random rand;
    
    private List<GameObject> asteroids;
    private List<GameObject> powerups;
    private Vector3 scale;

    private void drawAsteroid(float x, float y) {
        GameObject asteroid;
        if(rand.Next()%2 == 0){
            asteroid = GameObject.Instantiate(asteroid1, new Vector3(-1000, -1000, 0), Quaternion.identity, transform);
        }
        else{
            asteroid = GameObject.Instantiate(asteroid2, new Vector3(-1000, -1000, 0), Quaternion.identity, transform);
        }
        asteroid.transform.localPosition = new Vector3(x, y, 0);
        asteroid.transform.localScale = scale;
        asteroids.Add(asteroid);
    }

    private void drawPowerup(float x, float y) {
        GameObject powerup = null;
        if (!Constants.getEnergy())
        {
            int i = rand.Next() % powerupBodies.Length;

            powerup = GameObject.Instantiate(powerupBodies[i].gameObject, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
        else
        {
            powerup = GameObject.Instantiate(batteryTarget.gameObject, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
        
        
        
        powerup.transform.localPosition = new Vector3(x, y, 0);
        powerup.transform.localScale = scale;
        powerups.Add(powerup);
        
    }

    public void drawBoard(int[,] board, bool wormhole, float camWidth, int N){
        //Debug.Log("Calling Frame.drawBoard");
        asteroids = new List<GameObject>();
        powerups = new List<GameObject>();
        float unit = 40 * camWidth/(float)N;
        for(int r = N-1; r >= 0; r--){
            for(int c = 0; c < N; c++){
                float x = unit*c - 20*camWidth;
                float y = unit*r;
                switch(board[r, c]){
                    case 1:
                        drawAsteroid(x, y);
                    break;
                    case 2:
                        if(wormhole){
                            //TODO Draw wormhole at x, y
                        }
                    break;
                    case 3:
                        drawPowerup(x, y);
                    break;
                }
            }
        }

    }
    
    public Vector2 getPosition() {
        return frameRB.position;
    }
    
    public void setPosition(Vector2 p) {
        frameRB.MovePosition(p);
    }
    
    public void setVelocity(Vector2 v) {
        frameRB.velocity = v;
    }

    void Awake() {
        Debug.Log("Calling Frame.Awake");
        rand = new System.Random();
        asteroids = new List<GameObject>();
        powerups = new List<GameObject>();
        powerupBodies = powerupTargets.gameObject.GetComponentsInChildren<Rigidbody2D>();
        frameRB = gameObject.AddComponent<Rigidbody2D>();
        frameRB.isKinematic = true;
        scale = new Vector3(0.2f, 0.2f, 1);
    }

}
