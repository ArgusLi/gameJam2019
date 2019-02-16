using System;
using System.Collections.Generic;
namespace WorldGenTest{

    class Test{

        private class World{
            int N;
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
        }

        static void Main(){
            int N = 31;
            World[] worlds = new World[4];
            for(int i = 0; i < worlds.Length; i++){
                worlds[i] = new World(N);
                fill(worlds[i]);
            }

            List<char> path = new List<char>();
            List<char> moves = new List<char>();
            for(int i = 0; i < N; i++){
                moves.Add('N');
            }
            Random r = new Random();
            int lefts = r.Next(N/2);
            int ups = r.Next(N/2);
            for(int i = 0; i < lefts; i++){
                moves.Add('L');
                moves.Add('R');
            }
            for(int i = 0; i < ups; i++){
                moves.Add('U');
                moves.Add('D');
            }

            bool up = false; 
            bool down = false;
            bool left = false;
            bool right = false;
            foreach(World world in worlds){
                switch(world.direction){
                    case 'U':
                        up = true;
                        break;
                    case 'D':
                        down = true;
                        break;
                    case 'L':
                        left = true;
                        break;
                    case 'R':
                        right = true;
                        break;
                }
            }
            while(moves.Count != 0){
                int index = r.Next(moves.Count);
                char dir = moves[index];
                int vertDisplacement = 0;
                int horDisplacement = 0;
                switch(dir){
                    case 'U':
                        if(vertDisplacement+1 >= N/2){
                            continue;
                        }
                        vertDisplacement++;
                        break;
                    case 'D':
                        if(vertDisplacement-1 >= N/2){
                            continue;
                        }
                        vertDisplacement--;
                        break;
                    case 'L':
                        if(horDisplacement-1 >= N/2){
                            continue;
                        }
                        horDisplacement--;
                        break;
                    case 'R':
                        if(horDisplacement+1 >= N/2){
                            continue;
                        }
                        horDisplacement++;
                        break;
                    case 'N':
                        if(up){
                            if(vertDisplacement+1 >= N/2){
                                continue;
                            }
                            vertDisplacement++;
                        }
                        if(down){
                            if(vertDisplacement-1 >= N/2){
                                continue;
                            }
                            vertDisplacement--;
                        }
                        if(left){
                            if(horDisplacement-1 >= N/2){
                                continue;
                            }
                            horDisplacement--;
                        }
                        if(right){
                            if(horDisplacement+1 >= N/2){
                                continue;
                            }
                            horDisplacement++;
                        }
                        break;
                }
                path.Add(dir);
                moves.RemoveAt(index);
            }

            

            for(int i = 0; i < worlds.Length; i++){
                // write path into world

                // char dir = path.next();
                // if(dir == 'N'){
                //     dir = worlds[i].direction;
                // }

                // logic for u d l r
            }




        }

        static void fill(World world){
            Random r = new Random();
            for(int i = 0; i < world.board.GetLength(0); i++){
                for(int j = 0; j < world.board.GetLength(1); j++){
                    world.board[i, j] = 1;
                }
            }
        }


    }
}