using System.Collections.Generic;

public class Player
{
	public int income = 0;
	public int reputation = 0;
	public int population = 0;
	public int money = 15;

	public int doubleCounters = 3;

	private HexGrid map = new HexGrid();

	public bool HasAt(int q, int r)
	{
		return map.HasAt(q, r);
	}

	public Tile Get(Game game, int q, int r)
	{
		return game.pack.GetMetadata()[map.Get(q, r)];
	}

	public Tile GetNeighbor(Game game, int q, int r, HexDirection direction)
	{
		return game.pack.GetMetadata()[map.GetNeighbor(q, r, direction)];
	}

	public Tile[] GetNeighbors(Game game, int q, int r)
	{
		List<int> ids = map.GetNeighbors(q, r);

		var ret = new List<Tile>();
		foreach (int id in ids)
		{
			if (id == -1)
			{
				continue;
			}

			var tile = game.pack.GetMetadata()[id];
			ret.Add(tile);
		}

		return ret.ToArray();
	}

	public void Set(Game game, int q, int r, int tileID)
	{
		map.Set(q, r, tileID);
		return;
	}

	public Tile[] GetTiles(Game game)
	{
		int[] ids = map.GetTiles();
		Tile[] tiles = new Tile[ids.Length];

		for (int i = 0; i < ids.Length; i++)
		{
			tiles[i] = game.pack.GetMetadata()[ids[i]];
		}

		return tiles;
	}

	public TileData[] GetTileData(Game game)
	{
		return map.GetTileData(game, this);
	}
}
