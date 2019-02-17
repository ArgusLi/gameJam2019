using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameJob : MonoBehaviour
{
    private int N = 9;
    private int numWorlds = 4;
    private WorldGenerator.World[] worlds;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    private Camera[] cams;

    private float lastFrameY;

    public void drawFrames(List<int[,]> frames){
        float unit = cams[0].orthographicSize*2/(float)N;
        for(int i = 0; i < numWorlds; i++){
            for(int r = N-1; r >= 0; r--){
                for(int c = 0; c < N; c++){
                    switch(frames[i][r, c]){
                        case 1:
                            float x = cams[i].rect.x + unit*c;
                            float y = cams[i].rect.y + unit;
                            ObstacleManager.PlaceObstacle(x, y);
                            break;
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        worlds = new WorldGenerator.World[numWorlds];
        cams = new Camera[]{cam1, cam2, cam3, cam4};
        for(int i = 0; i < numWorlds; i++){
            worlds[i] = new WorldGenerator.World(N);
        }
        drawFrames(WorldGenerator.generateWorld(worlds, N));
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
