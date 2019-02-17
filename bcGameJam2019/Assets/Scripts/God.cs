using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public int N = 9; // NxN matrices

    private World[] worlds;
    private float runningScoreTotal;
    private bool energyMode = false;

    void launchNextFrame() {
        Debug.Log("Calling God.launchNextFrame");
        List<int[,]> boards = WorldGenerator.generateWorld(worlds, N);
        for(int i = 0; i < worlds.Length; i++){
            worlds[i].drawFrame(boards[i]);
        }
    }
    
    void Start() {
        Debug.Log("Calling God.Start");
        worlds = gameObject.GetComponentsInChildren<World>();
        for(int i = 0; i < worlds.Length; i++) {
            worlds[i].transform.localPosition = new Vector3(100*i, 0, 0);
        }
    }
    
    //TODO: when ready, call launchNextFrame

    public crash(float score, GameShip ship){
        runningScoreTotal += score;
        energyMode = true;
    }

    IEnumerator LoadAfterDelay() {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("score", runningScoreTotal);
    void Update() {
        for(int i = 0; i < worlds.Length; i++) {
            if (!worlds[i].ReadyToDraw()) {
                return;
            }
        }   
        launchNextFrame();
    }
}
