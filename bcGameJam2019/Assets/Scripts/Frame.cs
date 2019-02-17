using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Frame : MonoBehaviour
{

    public GameObject asteroid1;
    public GameObject asteroid2;

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

    public void drawBoard(int[,] board, bool wormhole, float camWidth, int N){
        float unit = camWidth/(float)N;
        for(int r = N-1; r >= 0; r--){
            for(int c = 0; c < N; c++){
                switch(board[r, c]){
                    case 1:
                        float x = unit*c;
                        float y =  unit*r;
                        drawAsteroid(x, y);
                    break;
                    case 2:
                        if(wormhole){
                            // Draw wormhole at 
                            x = unit*c;
                            y =  unit*r;
                        }
                    break;
                    case 3:
                        // Draw Powerup
                    break;
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        // asteroids = gameObject.GetComponentsInChildren<Rigidbody2D>();
        // drawAsteroid(0f,0f);

    }

}
