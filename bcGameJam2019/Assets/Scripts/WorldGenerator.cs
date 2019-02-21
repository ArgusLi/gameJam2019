using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator{

    public static List<int[,]> generateWorld(World[] w, int n){
        System.Random r = new System.Random();
        int N = n;
        World[] worlds = w;
        for(int i = 0; i < worlds.Length; i++){
            fill(worlds[i], r);
        }


        List<char> path = new List<char>();
        List<char> moves = new List<char>();
        for(int i = 0; i < N; i++){
            moves.Add('N');
        }
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

    //For test purposes only
    static int boardSum(int[,] board){
        int sum = 0;
        for(int i = 0; i < board.GetLength(0); i++){
            for(int j = 0; j < board.GetLength(1); j++){
                sum += board[i,j];
            }
        }
        return sum;
    }

    private static List<int[,]> getWorldFrames(World[] w){
        List<int[,]> frames = new List<int[,]>();
        for(int i = 0; i < w.Length; i++){
            if(w[i].direction == 'L'){
                frames.Add(rotate(w[i].board, 1, w[i].N));
            }else if(w[i].direction == 'D'){
                frames.Add(rotate(w[i].board, 2, w[i].N));
            }else if(w[i].direction == 'R'){
                frames.Add(rotate(w[i].board, 3, w[i].N));
            }else{
                frames.Add(w[i].board);
            }
        }
        foreach(int[,] board in frames){
            Debug.Log(boardSum(board));
        }
        return frames;
    }

    private static int[,] rotate(int[,] A, int num, int n){
        for(int i = 0; i < num; i++){
            for(int j = 0; j < n/2; j++){
                for(int k = 0; k < n - j - 1; k++){
                    int temp = A[j, k];
                    A[j, k] = A[n - 1 - k, j];
                    A[n - 1 - k, j] = A[n - 1 - j, n - 1 - k];
                    A[n - 1 - j, n - 1 - k] = A[k, n - 1 - j];
                    A[k, n - 1 - j] = temp;
                }
            }
        }
        return A;
    }

    static void fill(World world, System.Random r){
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