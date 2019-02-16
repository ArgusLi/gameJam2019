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
                posX = N/2;
                posY = N/2;
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

        static void Main(){
            int N = 11;
            World[] worlds = new World[4];
            for(int i = 0; i < worlds.Length; i++){
                worlds[i] = new World(N);
                fill(worlds[i]);
            }
            worlds[1].direction = 'L';
            worlds[2].direction = 'R';
            worlds[3].direction = 'D';




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
                        if(Math.Abs(vertDisplacement-1) >= N/2){
                            continue;
                        }
                        vertDisplacement--;
                        break;
                    case 'D':
                        if(Math.Abs(vertDisplacement+1) >= N/2){
                            continue;
                        }
                        vertDisplacement++;
                        break;
                    case 'L':
                        if(Math.Abs(horDisplacement-1) >= N/2){
                            continue;
                        }
                        horDisplacement--;
                        break;
                    case 'R':
                        if(Math.Abs(horDisplacement+1) >= N/2){
                            continue;
                        }
                        horDisplacement++;
                        break;
                    case 'N':
                        if(up){
                            if(Math.Abs(vertDisplacement-1) >= N/2){
                                continue;
                            }
                            vertDisplacement--;
                        }
                        if(down){
                            if(Math.Abs(vertDisplacement+1) >= N/2){
                                continue;
                            }
                            vertDisplacement++;
                        }
                        if(left){
                            if(Math.Abs(horDisplacement-1) >= N/2){
                                continue;
                            }
                            horDisplacement--;
                        }
                        if(right){
                            if(Math.Abs(horDisplacement+1) >= N/2){
                                continue;
                            }
                            horDisplacement++;
                        }
                        break;
                }
                path.Add(dir);
                moves.RemoveAt(index);
            }
            Console.WriteLine(path.ToArray());
            for(int i = 0; i < worlds.Length; i++){
				// write path into world
				int posx = 0;
				int posy = 0;
				switch (worlds[i].direction) {
					case 'L':
						posx = N-1;
						posy = N / 2;
						break;
					case 'R':
						posx = 0;
						posy = N / 2;
						break;
					case 'U':
						posy = N - 1;
						posx = N / 2;
						break;
					case 'D':
						posy = 0;
						posx = N / 2;
						break;
				}

				worlds[i].board[posx, posy] = 0;
				for (int j = 0; j < path.Count; j++){
					char move = path[j];
					if (move == 'N'){
						move = worlds[i].direction;
					}
					switch (move){
						case 'L':
							posx--;
							break;
						case 'R':
							posx++;
							break;
						case 'U':
							posy--;
							break;
						case 'D':
							posy++;
							break;
					}
                    try{
					    worlds[i].board[posx, posy] = 0;
                    }
                    catch(System.Exception e){
                        Console.WriteLine("Blame Sean 5");
                    }
				}
            }
            Console.WriteLine(worlds[0]);
            Console.WriteLine(worlds[1]);
            Console.WriteLine(worlds[2]);
            Console.WriteLine(worlds[3]);





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