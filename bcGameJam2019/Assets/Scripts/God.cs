using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public int N = 9; // NxN matrices

    private World[] worlds;
    private float runningScoreTotal;
    private int energy;
    private GameShip crashed;

    void launchNextFrame()
    {
        Debug.Log("Calling God.launchNextFrame");
        List<int[,]> boards = WorldGenerator.generateWorld(worlds, N);
        for (int i = 0; i < worlds.Length; i++)
        {
            worlds[i].drawFrame(boards[i]);
        }
    }

    void Start()
    {
        Debug.Log("Calling God.Start");
        worlds = gameObject.GetComponentsInChildren<World>();
        for (int i = 0; i < worlds.Length; i++)
        {
            worlds[i].transform.localPosition = new Vector3(100 * i+100, 0, 0);
        }
        crashed = null;
    }

    //TODO: when ready, call launchNextFrame

    public void crash(float score, GameShip ship)
    {
        if(ship != null)
        {
            runningScoreTotal += score;
            StartCoroutine(LoadAfterDelay());
        }
        runningScoreTotal += score;
        energy = 0;
        Constants.setEnergy(true);
        crashed = ship;
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

    void Update()
    {
        for (int i = 0; i < worlds.Length; i++)
        {
            if (!worlds[i].ReadyToDraw())
            {
                return;
            }
        }
        launchNextFrame();
    }

    void CollectEnergy()
    {
        energy++;
        if(energy >= 3)
        {
            Revive();
        }
    }

    void Revive()
    {
        Constants.setEnergy(false);
        //wait for frame change
        crashed.respawn();
    }


}
