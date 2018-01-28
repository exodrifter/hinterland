using System;
using System.Collections.Generic;

[Serializable]
public class HexGrid
{	
	public Dictionary<HexPosition, HexGridTile> Tiles
	{
		get { return tiles; }
	}
	private Dictionary<HexPosition, HexGridTile> tiles = new Dictionary<HexPosition, HexGridTile>();

	public bool HasAt(int q, int r)
	{
		return tiles.ContainsKey(new HexPosition(q, r));
	}

	public HexGridTile Get(int q, int r)
	{
		if (HasAt(q, r))
		{
			return tiles[new HexPosition(q, r)];
		}

		return null;
	}

	public HexGridTile GetNeighbor(int q, int r, HexDirection direction)
	{
		HexGridTile hexGridTile = Get (q + direction.GetDQ (), r + direction.GetDR ());
		if (hexGridTile != null)
		{
			return hexGridTile;
		}
		return hexGridTile;
	}

	public List<HexGridTile> GetNeighbors(int q, int r)
	{
		var ret = new List<HexGridTile>()
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
			if (Util.IsNull(ret[i]))
			{
				ret.RemoveAt(i);
			}
		}

		return ret;
	}

	internal void Set(int q, int r, int tileID, bool isDoubled)
	{
		tiles[new HexPosition(q, r)] = new HexGridTile(tileID, isDoubled);
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
}
