using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Frame : MonoBehaviour
{

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject powerupTargets;

    private Rigidbody2D[] powerups;
    private System.Random rand;

    private void drawAsteroid(float x, float y){
        int i = rand.Next();
        GameObject asteroid;
        if(i%2 == 0){
            asteroid = GameObject.Instantiate(asteroid1, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
        else{
            asteroid = GameObject.Instantiate(asteroid1, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
        asteroid.transform.localPosition = new Vector3(x, y, 0);
    }

    private void drawPowerup(float x, float y){
        GameObject powerup;
        int i = rand.Next()%powerups.Length;
        
        powerup = GameObject.Instantiate(powerups[i].gameObject, new Vector3(x, y, 0), Quaternion.identity, transform);
        
        powerup.transform.localPosition = new Vector3(x, y, 0);
    }

    public void drawBoard(int[,] board, bool wormhole, float camWidth, int N){
        float unit = camWidth/(float)N;
        for(int r = N-1; r >= 0; r--){
            for(int c = 0; c < N; c++){
                float x = unit*c;
                float y =  unit*r;
                switch(board[r, c]){
                    case 1:
                        drawAsteroid(x, y);
                    break;
                    case 2:
                        if(wormhole){
                            // Draw wormhole at x, y
                        }
                    break;
                    case 3:
                        drawAsteroid(x, y);
                    break;
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        powerups = powerupTargets.gameObject.GetComponentsInChildren<Rigidbody2D>();
    }

}
