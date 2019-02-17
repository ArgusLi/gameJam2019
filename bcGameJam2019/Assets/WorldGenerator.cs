using System;
using System.Collections.Generic;

public class WorldGenerator{
    public static List<int[,]> getWorldFrames(World[] worlds){
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
                posX = N/2;
                posY = N/2;
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

        static List<int[,]> generateWorld(World[] w, int n){
            int N = n;
            World[] worlds = w;
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
            int lefts = r.Next(N);
            int ups = r.Next(N);
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
            for(int i = 0; i < worlds.Length; i++){
				// write path into world
				int posx = 0;
				int posy = 0;
				switch (worlds[i].direction) {
					case 'L':
						posx = N-1;
						posy = N / 2;
						worlds[i].board[posy+1, posx] = 0;
						worlds[i].board[posy-1, posx] = 0;
						worlds[i].board[posy+1, posx-1] = 0;
						worlds[i].board[posy-1, posx-1] = 0;
						worlds[i].board[posy, posx-1] = 0;
						break;
					case 'R':
						posx = 0;
						posy = N / 2;
						worlds[i].board[posy+1, posx] = 0;
						worlds[i].board[posy-1, posx] = 0;
						worlds[i].board[posy+1, posx+1] = 0;
						worlds[i].board[posy-1, posx+1] = 0;
						worlds[i].board[posy, posx+1] = 0;
						break;
					case 'U':
						posy = N - 1;
						posx = N / 2;
						worlds[i].board[posy, posx+1] = 0;
						worlds[i].board[posy, posx-1] = 0;
						worlds[i].board[posy-1, posx+1] = 0;
						worlds[i].board[posy-1, posx-1] = 0;
						worlds[i].board[posy-1, posx] = 0;
						break;
					case 'D':
						posy = 0;
						posx = N / 2;
						worlds[i].board[posy, posx+1] = 0;
						worlds[i].board[posy, posx-1] = 0;
						worlds[i].board[posy+1, posx+1] = 0;
						worlds[i].board[posy+1, posx-1] = 0;
						worlds[i].board[posy+1, posx] = 0;
						break;
				}

				worlds[i].board[posy, posx] = 2;
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
					    if(worlds[i].board[posy, posx] == 1){
					        worlds[i].board[posy, posx] = 0;
					    }
                    }
                    catch(System.Exception e){
                        ;
                    }
				}
            }
            return getWorldFrames(worlds);
        }

        static void fill(World world){
            Random r = new Random();
            for(int i = 0; i < world.board.GetLength(0); i++){
                for(int j = 0; j < world.board.GetLength(1); j++){
                    world.board[i, j] = 1;
                }
            }
            int gaps = 0;
            while(gaps < 40){
                for(int i = 0; i < world.board.GetLength(0); i++){
                    for(int j = 0; j < world.board.GetLength(1); j++){
                        int rand = r.Next(2);
                        if(rand == 0 && world.board[i, j] == 1){
                            world.board[i, j] = 0;
                            gaps++;
                        }
                    }
                }
            }
            for(int i = 0; i < world.board.GetLength(0); i++){
                for(int j = 0; j < world.board.GetLength(1); j++){
                    int rand = r.Next(16);
                    if(rand == 0 && world.board[i, j] == 0){
                        world.board[i, j] = 3;
                    }
                }
            }
        }
}