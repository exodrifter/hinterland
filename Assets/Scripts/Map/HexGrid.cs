using System;
using System.Collections.Generic;

[Serializable]
public class HexGrid
{
	private Dictionary<HexPosition, int> tiles = new Dictionary<HexPosition, int>();

	public bool HasAt(int q, int r)
	{
		return tiles.ContainsKey(new HexPosition(q, r));
	}

	public int Get(int q, int r)
	{
		if (HasAt(q, r))
		{
			return tiles[new HexPosition(q, r)];
		}

		return -1;
	}

	public int GetNeighbor(int q, int r, HexDirection direction)
	{
		return Get(q + direction.GetDQ(), r + direction.GetDR());
	}

	public List<int> GetNeighbors(int q, int r)
	{
		var ret = new List<int>()
		{
			GetNeighbor(q, r, HexDirection.North),
			GetNeighbor(q, r, HexDirection.South),
			GetNeighbor(q, r, HexDirection.NorthEast),
			GetNeighbor(q, r, HexDirection.SouthEast),
			GetNeighbor(q, r, HexDirection.NorthWest),
			GetNeighbor(q, r, HexDirection.SouthWest),
		};

		for (int i = ret.Count - 1; i >= 0; --i)
		{
			if (ret[i] < 0)
			{
				ret.RemoveAt(i);
			}
		}

		return ret;
	}

	internal void Set(int q, int r, int tileID)
	{
		tiles[new HexPosition(q, r)] = tileID;
	}

	public static bool IsAdjacent(int q, int r, int q2, int r2)
	{
		return IsAdjacentInternal(HexDirection.North, q, r, q2, r2)
			|| IsAdjacentInternal(HexDirection.NorthEast, q, r, q2, r2)
			|| IsAdjacentInternal(HexDirection.NorthWest, q, r, q2, r2)
			|| IsAdjacentInternal(HexDirection.South, q, r, q2, r2)
			|| IsAdjacentInternal(HexDirection.SouthEast, q, r, q2, r2)
			|| IsAdjacentInternal(HexDirection.SouthWest, q, r, q2, r2);
	}

	private static bool IsAdjacentInternal
		(HexDirection direction, int q, int r, int q2, int r2)
	{
		return q + direction.GetDQ() == q2
			&& r + direction.GetDR() == r2;
	}

	public int[] GetTiles()
	{
		var list = new List<int>();
		foreach (var value in tiles.Values)
		{
			list.Add(value);
		}
		return list.ToArray();
	}

	public TileData[] GetTileData(Game game, Player player)
	{
		var list = new List<TileData>();

		foreach (var kvp in tiles)
		{
			var hash = kvp.Key;
			var q = hash.q;
			var r = hash.r;
			var id = kvp.Value;

			list.Add(new TileData(game.pack.GetMetadata()[id], player, id, game.pack.GetLocalization()[id], q, r));
		}

		return list.ToArray();
	}
}
