using System;
using System.Collections.Generic;

public class WorldGenerator{
    public static List<int[,]> getWorldFrames(List<World> worlds){
        List<int[,]> ret = new List<int[,]>();
        foreach(World world in worlds){
            ret.Add(new int[world.N, world.N]);
        }
        return ret;
    }



    public class World{
            public int N;
            public int[,] board;
            public char direction;
            public int posX;
            public int posY;

            public World(int n){
                N = n;
                board = new int[N, N];
                direction = 'U';
                posX = N/2 + 1;
                posY = N/2 + 1;
            }
            public override string ToString(){
                string ret = "";
                for(int i = 0; i < N; i++){
                    for(int j = 0; j < N; j++){
                        if(board[j, i] == 0){
                            ret += "  ";
                        }
                        else{
                            ret += "# ";
                        }
                        // ret += board[j, i] + " ";
                    }
                    ret += "\n";
                }
                return ret;
            }
        }
}