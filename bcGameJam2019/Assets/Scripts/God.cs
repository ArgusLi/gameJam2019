using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public int N = 9; // NxN matrices

    private World[] worlds;
    private float runningScoreTotal;
    private float energyClockStart;
    private int energy;
    private List<GameShip> crashed;
    private bool readyToRevive;

    //For test purposes only
    int boardSum(int[,] board){
        int sum = 0;
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                sum += board[i,j];
            }
        }
        return sum;
    }

    void launchNextFrame()
    {
        // Debug.Log("Calling God.launchNextFrame");
        List<int[,]> boards = WorldGenerator.generateWorld(worlds, N);
        // foreach(int[,] board in boards){
        //     Debug.Log(boardSum(board));
        // }
        for (int i = 0; i < worlds.Length; i++)
        {
            worlds[i].drawFrame(boards[i]);
        }
    }

    void Start()
    {
        // Debug.Log("Calling God.Start");
        worlds = gameObject.GetComponentsInChildren<World>();
        for (int i = 0; i < worlds.Length; i++)
        {
            worlds[i].transform.localPosition = new Vector3(100 * i+100, 0, 0);
        }
        crashed = new List<GameShip>();
    }

    //TODO: when ready, call launchNextFrame

    public void crash(float score, GameShip ship)
    {
        runningScoreTotal += score;    
        if(Constants.getEnergy() == false){
            energy = 0;
            energyClockStart = Time.unscaledTime;
            Constants.setEnergy(true);
        }
        crashed.Add(ship);
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

    void Update()
    {
        // run out of time on energy meter
        if(Constants.getEnergy() && Time.unscaledTime-energyClockStart > 30){
            // launch end scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");

            // load end scene after 1s delay
            // StartCoroutine(LoadAfterDelay());
        }

        for (int i = 0; i < worlds.Length; i++)
        {
            if (!worlds[i].ReadyToDraw())
            {
                return;
            }
        }
        launchNextFrame();
    }

    public void CollectEnergy()
    {
        energy++;
        // TODO:: Update energy bar

        if(energy >= 3)
        {
            Constants.setEnergy(false);
            Revive();
            // TODO:: Remove energy bar from screen after brief delay
        }
    }

    void Revive()
    {
        foreach(GameShip ship in crashed){
            ship.respawn();
        }
    }


}
