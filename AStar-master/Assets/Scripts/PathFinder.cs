using System.Collections.Generic;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		var GridPosition = new Grid.Position();
		var path = new List<Grid.Position>();
		GridPosition == fromPosition.x;
		path.Add( fromPosition );
		path.Add( toPosition);
		while(GridPosition < toPosition.x)
		{
			GridPosition ++;
		}


		return path;
	}
}
