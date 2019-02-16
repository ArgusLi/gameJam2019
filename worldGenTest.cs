using System;
using System.Collections.Generic;
// using System.Random;
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
            Set<char> s = new Set<char>();
            for(int i = 0; i < N; i++){
                s.add('N');
            }
            int lefts = r.Next(N/2);
            int ups = r.Next(N/2);
            for(int i = 0; i < lefts; i++){
                s.add('L');
                s.add('R');
            }
            for(int i = 0; i < ups; i++){
                s.add('U');
                s.add('D');
            }

            bool up = false; 
            bool down = false;
            bool left = false;
            bool right = false;

            while(!s.isEmpty()){

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