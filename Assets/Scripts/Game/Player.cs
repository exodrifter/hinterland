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

	public TileData Get(Game game, int q, int r)
	{
		HexGridTile hexGridTile = map.Get(q, r);
		var tiledata = new TileData (game.pack.GetMetadata () [hexGridTile.tileID], this,
			hexGridTile.tileID, game.pack.GetTileLocalization () [hexGridTile.tileID], q, r, hexGridTile.isDoubled);
		return tiledata;
	}

	public Tile GetNeighbor(Game game, int q, int r, HexDirection direction)
	{
		return game.pack.GetMetadata()[map.GetNeighbor(q, r, direction).tileID];
	}

	public Tile[] GetNeighbors(Game game, int q, int r)
	{
		List<HexGridTile> tiles = map.GetNeighbors(q, r);

		var ret = new List<Tile>();
		foreach (HexGridTile hexGridTile in tiles)
		{
			if (hexGridTile.tileID == -1)
			{
				continue;
			}

			var tile = game.pack.GetMetadata()[hexGridTile.tileID];
			ret.Add(tile);
		}

		return ret.ToArray();
	}

	public void Set(Game game, int q, int r, int tileID, bool isDoubled)
	{
		map.Set(q, r, tileID, isDoubled);
		return;
	}

	public Tile[] GetTiles(Game game)
	{
		List<HexGridTile> hexGridTiles = new List<HexGridTile>();
		foreach (var value in map.Tiles.Values)
		{
			hexGridTiles.Add(value);
		}

		Tile[] tiles = new Tile[hexGridTiles.Count];

		for (int i = 0; i < hexGridTiles.Count; i++)
		{
			tiles[i] = game.pack.GetMetadata()[hexGridTiles[i].tileID];
		}

		return tiles;
	}

	public TileData[] GetTileData(Game game)
	{
		var list = new List<TileData>();

		foreach (var kvp in map.Tiles)
		{
			var hash = kvp.Key;
			var q = hash.q;
			var r = hash.r;
			var hexGrid = kvp.Value;
			var id = hexGrid.tileID;
			var isDoubled = hexGrid.isDoubled;

			list.Add(new TileData(game.pack.GetMetadata()[id], this, id, game.pack.GetTileLocalization()[id], q, r, isDoubled));
		}
		return list.ToArray();
	}
}
