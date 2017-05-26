using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
    public static List<Grid.Position> FindPath(Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition)
    {
		

        Queue<Grid.Position> queue = new Queue<Grid.Position>();
        List<Grid.Position> grid = new List<Grid.Position>();
		HashSet<Grid.Position> path = new HashSet<Grid.Position>();

        Grid.Position[,] Tiles = new Grid.Position[tiles.GetLength(0), tiles.GetLength(1)];
        queue.Enqueue(fromPosition);
        Tiles[fromPosition.x, fromPosition.y] = fromPosition;
	

		if (tiles[toPosition.x, toPosition.y].isWall) 
		{
			return new List<Grid.Position>();
		//	return Tile(tiles [toPosition.x, toPosition.y]);
		}

        while (queue.Count > 0){
            Grid.Position dequeuepos = queue.Dequeue();

            if (dequeuepos.Equals(toPosition)){
                grid.Add(dequeuepos);
                while (dequeuepos.x != fromPosition.x || dequeuepos.y != fromPosition.y){
                    dequeuepos = Tiles[dequeuepos.x, dequeuepos.y];
                    grid.Add(dequeuepos);
                }
                grid.Reverse();
                break;
            }



            else{
                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x - 1, dequeuepos.y), tiles) && !path.Contains(new Grid.Position(dequeuepos.x - 1, dequeuepos.y))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x - 1, dequeuepos.y));
                    path.Add(new Grid.Position(dequeuepos.x - 1, dequeuepos.y));
                    Tiles[dequeuepos.x - 1, dequeuepos.y] = dequeuepos;
                }
				if (Tile.InsideGrid(new Grid.Position(dequeuepos.x + 1, dequeuepos.y), tiles)&& !path.Contains(new Grid.Position(dequeuepos.x + 1, dequeuepos.y))){
					queue.Enqueue(new Grid.Position(dequeuepos.x + 1, dequeuepos.y));
					path.Add(new Grid.Position(dequeuepos.x + 1, dequeuepos.y));
					Tiles[dequeuepos.x + 1, dequeuepos.y] = dequeuepos;
				}
                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x, dequeuepos.y + 1), tiles) && !path.Contains(new Grid.Position(dequeuepos.x, dequeuepos.y + 1))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x, dequeuepos.y + 1));
                    path.Add(new Grid.Position(dequeuepos.x, dequeuepos.y + 1));
                    Tiles[dequeuepos.x, dequeuepos.y + 1] = dequeuepos;
                }
                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x, dequeuepos.y - 1), tiles) && !path.Contains(new Grid.Position(dequeuepos.x, dequeuepos.y - 1))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x, dequeuepos.y - 1));
                    path.Add(new Grid.Position(dequeuepos.x, dequeuepos.y - 1));
                    Tiles[dequeuepos.x, dequeuepos.y - 1] = dequeuepos;
                }

                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x + 1, dequeuepos.y + 1), tiles)  && !path.Contains(new Grid.Position(dequeuepos.x + 1, dequeuepos.y + 1))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x + 1, dequeuepos.y + 1));
                    path.Add(new Grid.Position(dequeuepos.x + 1, dequeuepos.y + 1));
                    Tiles[dequeuepos.x + 1, dequeuepos.y + 1] = dequeuepos;
                }

                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x - 1, dequeuepos.y + 1), tiles)  && !path.Contains(new Grid.Position(dequeuepos.x - 1, dequeuepos.y + 1))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x - 1, dequeuepos.y + 1));
                    path.Add(new Grid.Position(dequeuepos.x - 1, dequeuepos.y + 1));
                    Tiles[dequeuepos.x - 1, dequeuepos.y + 1] = dequeuepos;
                }

                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x + 1, dequeuepos.y - 1), tiles) && !path.Contains(new Grid.Position(dequeuepos.x + 1, dequeuepos.y - 1))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x + 1, dequeuepos.y - 1));
                    path.Add(new Grid.Position(dequeuepos.x + 1, dequeuepos.y - 1));
                    Tiles[dequeuepos.x + 1, dequeuepos.y - 1] = dequeuepos;
                }

                if (Tile.InsideGrid(new Grid.Position(dequeuepos.x - 1, dequeuepos.y - 1), tiles) && !path.Contains(new Grid.Position(dequeuepos.x - 1, dequeuepos.y - 1))){
                    queue.Enqueue(new Grid.Position(dequeuepos.x - 1, dequeuepos.y - 1));
                    Tiles[dequeuepos.x - 1, dequeuepos.y - 1] = dequeuepos;
                    path.Add(new Grid.Position(dequeuepos.x - 1, dequeuepos.y - 1));
                }
            }
        }
      
        return grid;
    }
}
