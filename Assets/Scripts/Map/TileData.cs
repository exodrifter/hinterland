using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : Tile
{
	public Player Player
	{
		get { return player; }
	}
	private Player player;

	public int Q
	{
		get { return q; }
	}
	private int q;

	public int R
	{
		get { return r; }
	}
	private int r;

	private const float size = 1;

	public TileData(Tile tile, Player player, int q, int r)
		: base(tile)
	{
		this.player = player;
		this.q = q;
		this.r = r;
	}

	public Vector3 GetPosition()
	{
		var x = size * 3f / 2f * q;
		var y = size * Mathf.Sqrt(3f) * (r + q / 2f);
		return new Vector3(x, -y, 0);
	}
}
