using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuadPos
{
    BottomLeft,
    TopLeft,
    BottomRight,
    TopRight
}

public class World : MonoBehaviour
{
    public Camera cam;
    public int[,] board;
    public int N;
    public char direction;

    public QuadPos quadPos;
    
    private bool started;
    private List<int[,]> boards;
    private Frame[] frames;
    private int posX;
    private int posY;
    private int speed;
    private bool wormhole;
    private int nextFrame;
    private Rigidbody2D cameraRB;

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
            }
            ret += "\n";
        }
        return ret;
    }
    
    public bool ReadyToDraw() {
        Frame lastFrame = frames[(nextFrame + 2) % 3];
        Vector2 lastPos = lastFrame.getPosition();
        float cameraY = cameraRB.position.y;
        if (lastPos.y == 0f) {
            Debug.Log("Ready: never drawn");
            return true;
        } else if (lastPos.y < cameraY - 10) {
            Debug.Log("Ready: offscreen ()");
            return true;
        } else {
            Debug.Log("Not ready: onscreen: frame=" + lastPos.y.ToString() + ", camera=" + cameraY.ToString());
            return false;
        }
    }
    
    public void drawFrame(int[,] board){
        //Debug.Log("Calling World.drawFrame");
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
        frames[nextFrame].setPosition(new Vector2(posX, posY+10));
        frames[nextFrame].drawBoard(frame, wormhole, cam.rect.width, N);
        frames[nextFrame].setVelocity(new Vector2(0, -2));
        
        nextFrame = (nextFrame + 1) % 3;
    }

    public void Awake()
    {
        Debug.Log("Calling World.Awake");
        cam.transform.localPosition = new Vector3(0,0,-0.5f);
        N = transform.parent.gameObject.GetComponent<God>().N;
        board = new int[N, N];
        direction = 'U';
        posX = N / 2;
        posY = N / 2;
        speed = 2;
        wormhole = false;
        nextFrame = 0;
        frames = gameObject.GetComponentsInChildren<Frame>();
        cameraRB = cam.GetComponent<Rigidbody2D>();
        SetCamera();
        started = false;
    }

    public void enterWormhole(){
        wormhole = true;

        //TODO::ship and frame disappear
    }

    public void Rotate(){
        enterWormhole();
        float rotateFactor = 90f;
        System.Random r = new System.Random();
        if(r.Next()%2 == 0){
            rotateFactor = -90f;
        }
        cameraRB.rotation += rotateFactor;
    }

    public void Sync(){
        enterWormhole();
        God[] gods = gameObject.GetComponentsInParent<God>();
        World[] worlds = gods[0].gameObject.GetComponentsInChildren<World>();
        foreach (World world in worlds){
            if(world != this){
                world.GetSynced(direction, speed);
            }
        }
    }

    public void SetCamera()
    {
        float width = 0.0f;
        float height = 0.0f;
        float x = 0.0f;
        float y = 0.0f;
        float halfWidth = Screen.width / 2.0f;
        float halfHeight = Screen.height / 2.0f;
        if (Screen.width < Screen.height)
        {
            width = Screen.width / 2.0f;
            height = width;
            switch (quadPos)
            {
                case QuadPos.BottomLeft:
                    x = 0;
                    y = halfHeight - halfWidth;
                    break;
                case QuadPos.BottomRight:
                    x = halfWidth;
                    y = halfHeight - halfWidth;
                    break;
                case QuadPos.TopLeft:
                    x = 0;
                    y = halfHeight;
                    break;
                case QuadPos.TopRight:
                    x = halfWidth;
                    y = halfHeight;
                    break;
            }
        }
        else
        {
            height = Screen.height / 2.0f;
            width = height;
            switch (quadPos)
            {
                case QuadPos.BottomLeft:
                    x = halfWidth - halfHeight;
                    y = 0;
                    break;
                case QuadPos.BottomRight:
                    x = halfWidth;
                    y = 0;
                    break;
                case QuadPos.TopLeft:
                    x = halfWidth - halfHeight;
                    y = halfHeight;
                    break;
                case QuadPos.TopRight:
                    x = halfWidth;
                    y = halfHeight;
                    break;
            }
        }
        cam.pixelRect = new Rect(x, y, width, height);

    }

    public void GetSynced(char direction, int speed){
        enterWormhole();
        this.direction = direction;
        switch(direction){
            case 'U':
                cameraRB.rotation = 0f;
            break;
            case 'D':
                cameraRB.rotation = 180f;
            break;
            case 'L':
                cameraRB.rotation = 90f;
            break;
            case 'R':
                cameraRB.rotation = 270f;
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


