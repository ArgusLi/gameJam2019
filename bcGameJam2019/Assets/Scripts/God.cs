using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public int N = 9; // NxN matrices

    private World[] worlds;

    void launchNextFrame() {
        List<int[,]> boards = WorldGenerator.generateWorld(worlds, N);
        for(int i = 0; i < worlds.Length; i++){
            worlds[i].drawFrame(boards[i]);
        }
    }
    
    void Start() {
        worlds = gameObject.GetComponentsInChildren<World>();
        for(int i = 0; i < worlds.Length; i++) {
            worlds[i].transform.localPosition = new Vector3(100*i, 0, 0);
        }
    }
    
    //TODO: when ready, call launchNextFrame
}
