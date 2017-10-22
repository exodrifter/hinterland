using System;
using System.Collections.Generic;

public class Game
{
	public List<Player> players = new List<Player>();
	public Tile[] metadata = new Tile[0];

	/// <summary>
	/// Whose turn is it?
	/// </summary>
	public Player activePlayer;

	public void PlaceTile(int tileID, int q, int r)
	{
		Tile tile = metadata [tileID];
		PlaceTile (tile, q, r);
	}

	/// <summary>
	/// Steps the game forward one turn
	/// </summary>
	/// <param name="tile">The tile that was played.</param>
	public void PlaceTile(Tile tile, int q, int r)
	{
		// Check if the space is empty
		if (activePlayer.HasAt(q, r))
		{
			throw new InvalidOperationException();
		}
		// Check if the player has enough money
		if (activePlayer.money < tile.price)
		{
			throw new InvalidOperationException();
		}

		activePlayer.money -= tile.price;

		// Resolve tile rules
		var tileID = Array.IndexOf(metadata, tile);
		var tiledata = new TileData(tile, activePlayer, tileID, q, r);
		foreach (var rule in tile.rules)
		{
			rule.RunNow(this, activePlayer, tiledata);
		}

		// Place the tile
		activePlayer.Set(this, q, r, tile);

		// Resolve other tile rules
		foreach (var player in players)
		{
			foreach (var otherData in player.GetTileData(this))
			{
				foreach (var rule in tile.rules)
				{
					rule.RunUpdate(this, activePlayer, otherData, tiledata);
				}
			}
		}
	}

	public void DoubleTile(Tile tile, int q, int r)
	{
		// Check if the player has enough money
		if (activePlayer.money < tile.price)
		{
			throw new InvalidOperationException();
		}
		// Check if there are enough double counters
		if (activePlayer.doubleCounters <= 0)
		{
			throw new InvalidOperationException();
		}

		activePlayer.money -= tile.price;
		activePlayer.doubleCounters--;

		// Double rule effect
		var tileID = Array.IndexOf(metadata, tile);
		var tiledata = new TileData(tile, activePlayer, tileID, q, r);
		foreach (var rule in tile.rules)
		{
			rule.RunNow(this, activePlayer, tiledata);
		}
	}
}
