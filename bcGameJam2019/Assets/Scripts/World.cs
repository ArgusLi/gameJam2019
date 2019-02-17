using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public int N;
    public int[,] board;
    public char direction;
    public int posX;
    public int posY;
    public int speed;
    public bool wormhole;

    public World(int n){
        N = n;
        board = new int[N, N];
        direction = 'U';
        posX = N/2;
        posY = N/2;
        speed = 2;
        wormhole = false;
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
}

