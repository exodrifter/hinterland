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
		return game.metadata[map.Get(q, r)];
	}

	public Tile GetNeighbor(Game game, int q, int r, HexDirection direction)
	{
		return game.metadata[map.GetNeighbor(q, r, direction)];
	}

	public Tile[] GetNeighbors(Game game, int q, int r)
	{
		List<int> ids = map.GetNeighbors(q, r);

		var ret = new List<Tile>();
		foreach (int id in ids)
		{
			var tile = game.metadata[map.Get(q, r)];
			ret.Add(tile);
		}

		return ret.ToArray();
	}

	public void Set(Game game, int q, int r, Tile tile)
	{
		for (int i = 0; i < game.metadata.Length; i++)
		{
			if (game.metadata[i].Equals(tile))
			{
				map.Set(q, r, i);
				return;
			}
		}
	}

	public Tile[] GetTiles(Game game)
	{
		int[] ids = map.GetTiles();
		Tile[] tiles = new Tile[ids.Length];

		for (int i = 0; i < ids.Length; i++)
		{
			tiles[i] = game.metadata[ids[i]];
		}

		return tiles;
	}

	public TileData[] GetTileData(Game game)
	{
		return map.GetTileData(game, this);
	}
}
