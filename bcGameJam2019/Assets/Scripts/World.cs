using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public int N;
    public int[,] board;
    public List<int[,]> boards;
    public Frame[] frames;
    public Camera cam;
    public char direction;
    public int posX;
    public int posY;
    public int speed;
    public bool wormhole;
    public int nextFrame;

    public World(int n){
        N = n;
        board = new int[N, N];
        direction = 'U';
        posX = N/2;
        posY = N/2;
        speed = 2;
        wormhole = false;
        nextFrame = 0;
    }
    public override string ToString(){
        string ret = "";
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                if(board[i, j] == 0){
                    ret += "  ";
                }else if(board[i, j] == 2){
                    ret += "@ ";
                }else if(board[i, j] == 1){
                    ret += "# ";
                }else{
                    ret += "! ";
                }
                // ret += board[j, i] + " ";
            }
            ret += "\n";
        }
        return ret;
    }
    public void drawFrame(int[,] board){
        int[,] frame = new int[speed * N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < speed; k++)
                {
                    frame[i + k, j] = board[i, j];
                }
            }
        }
        frames[nextFrame].drawBoard(frame, wormhole, cam.rect.width, N);
        //Move frames[nextFrame] to on top of the frames[(nextFrame - 1) % 3]
        nextFrame = (nextFrame + 1) % 3;
    }

    public void Start()
    {
        cam.transform.localPosition = new Vector3(0,0,-0.5f);
        frames = gameObject.GetComponentsInChildren<Frame>();

    }

    public void enterWormhole(){
        wormhole = true;

        //TODO::ship and frame dissapear
    }

    public void Rotate(){
        enterWormhole();
        float rotateFactor = 90f;
        Random r = new Random();
        if(r.Next()%2 == 0){
            rotateFactor = -90f;
        }
        cam.transform.rotation += rotateFactor;
    }

    public void Sync(){
        enterWormhole();
        //TODO:: call GetSynched on all other worlds
    }

    public void GetSynced(char direction, int speed){
        enterWormhole();
        this.direction = direction;
        switch(direction){
            case 'U':
                cam.transform.rotation = 0f;
            break;
            case 'D':
                cam.transform.rotation = 180f;
            break;
            case 'L':
                cam.transform.rotation = 90f;
            break;
            case 'R':
                cam.transform.rotation = 270f;
            break;
        }
        this.speed = speed;
    }

    public void Slow(){
        enterWormhole();
        if(speed > 1){
            speed /= 2;
        }
    }

    public void Boost(){
        enterWormhole();
        if(speed <=2){
            speed *= 2;
        }
    }

}


