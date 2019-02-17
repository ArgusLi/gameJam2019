// using System.Collections;
// using System.Collections.Generic;
// using System;
// using UnityEngine;

// public class FrameJob : MonoBehaviour
// {
//     private int N = 9;
//     private World world;
//     public Camera camera;
    
//     private float lastFrameY;

//     public void drawFrames(List<int[,]> frames){
//         float unit = cams[0].orthographicSize*2/(float)N;
//         for(int i = 0; i < numWorlds; i++){
//             for(int r = N-1; r >= 0; r--){
//                 for(int c = 0; c < N; c++){
//                     switch(frames[i][r, c]){
//                         case 1:
//                             Vector3 camPosition = cams[i].gameObject.transform.position;
//                             float x = camPosition[1] + unit*c;
//                             float y = camPosition[0] - unit*r;
//                             if(i == 0){
//                                 Debug.Log("rect x: "+camPosition);
//                                 Debug.Log("ux: "+unit*c+" uy: "+unit*r);
//                                 Debug.Log("x: "+x+" y: "+y);
//                             }
//                             Debug.Log("Placing Rock");
//                             ObstacleManager.PlaceObstacle(x, y);
//                             break;
//                     }
//                 }
//             }
//         }
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         Debug.Log("CALLED");

//         worlds = new World[numWorlds];
//         cams = new Camera[]{cam1, cam2, cam3, cam4};
//         for(int i = 0; i < numWorlds; i++){
//             worlds[i] = new World(N);
//         }
//         // drawFrames(WorldGenerator.generateWorld(worlds, N));
//     }

// static bool x = true;

//     // Update is called once per frame
//     void Update()
//     {
//         if(x){
//             drawFrames(WorldGenerator.generateWorld(worlds, N));
//             x = false;
//         }
//     }
// }
