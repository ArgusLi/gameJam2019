using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    private World[] worlds;
    public int N = 9;

    void launchNextFrame(){
        List<int[,]> boards = WorldGenerator.generateWorld(worlds, N);
        for(int i = 0; i < worlds.Length; i++){
            worlds[i].drawFrame(boards[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        worlds = gameObject.GetComponentsInChildren<World>();
        for(int i = 0; i < worlds.Length; i++){
            worlds[i].transform.localPosition = new Vector3(100*i, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //launchNextFrame();
    }
}
