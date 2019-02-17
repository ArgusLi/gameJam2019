using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{

    Rigidbody2D[] asteroids;

    private void drawAsteroid(float x, float y){
        // GameObject asteroid = gameObject.Instantiate(asteroids[0].gameObject, new Vector3(x, y, 0), Quaternion.identity, transform);

    }

    public void drawBoard(int[,] board, bool wormhole){
        // float unit = cams[0].orthographicSize*2/(float)N;
        // for(int i = 0; i < numWorlds; i++){
        //     for(int r = N-1; r >= 0; r--){
        //         for(int c = 0; c < N; c++){
        //             switch(frames[i][r, c]){
        //                 case 1:
        //                     Vector3 camPosition = cams[i].gameObject.transform.position;
        //                     float x = camPosition[1] + unit*c;
        //                     float y = camPosition[0] - unit*r;
        //                     if(i == 0){
        //                         Debug.Log("rect x: "+camPosition);
        //                         Debug.Log("ux: "+unit*c+" uy: "+unit*r);
        //                         Debug.Log("x: "+x+" y: "+y);
        //                     }
        //                     Debug.Log("Placing Rock");
        //                     ObstacleManager.PlaceObstacle(x, y);
        //                     break;
        //             }
        //         }
        //     }
        // }

    }

    // Start is called before the first frame update
    void Start()
    {
        asteroids = gameObject.GetComponentsInChildren<Rigidbody2D>();
        drawAsteroid(0f,0f);

    }

}
