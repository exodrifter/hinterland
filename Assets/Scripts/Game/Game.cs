using System;
using System.Collections.Generic;

public class Game
{
	public List<Player> players = new List<Player>();
	public GamePack pack;

	/// <summary>
	/// Whose turn is it?
	/// </summary>
	public Player activePlayer;

	/// <summary>
	/// Steps the game forward one turn
	/// </summary>
	/// <param name="tile">The tile that was played.</param>
	public void PlaceTile(int tileID, int q, int r, int marketIndex = 0)
	{
		Tile tile = pack.GetMetadata()[tileID];

		// Check if the space is empty
		if (activePlayer.HasAt(q, r))
		{
			throw new InvalidOperationException();
		}
		// Check if the player has enough money
		int marketAdjustment = marketIndex > 1 ? (marketIndex - 1) * 2 : 0;
		if (activePlayer.money < tile.price + marketAdjustment)
		{
			PopupManager.Show ("Not enough money.");
			throw new InvalidOperationException();
		}

		activePlayer.money -= tile.price + marketAdjustment;
		activePlayer.income += tile.incomeBonus;
		activePlayer.population += tile.populationBonus;
		activePlayer.reputation += tile.reputationBonus;

		// Resolve tile rules
		var tiledata = new TileData(tile, activePlayer, tileID, pack.GetLocalization()[tileID], q, r, false);
		foreach (var rule in tile.rules)
		{
			rule.RunNow(this, activePlayer, tiledata);
		}

		// Place the tile
		activePlayer.Set(this, q, r, tileID, tiledata.IsDoubled);

		// Resolve other tile rules
		foreach (var player in players)
		{
			foreach (var otherData in player.GetTileData(this))
			{
				foreach (var rule in otherData.rules)
				{
					rule.RunUpdate(this, activePlayer, otherData, tiledata);
				}
			}
		}
	}

	public void DoubleTile(int q, int r)
	{
		TileData tile = activePlayer.Get (this, q, r);

		// Check if the player has enough money
		if (activePlayer.money < tile.price)
		{
			PopupManager.Show ("Not enough money.");
			throw new InvalidOperationException();
		}
		// Check if there are enough double counters
		if (activePlayer.doubleCounters <= 0)
		{
			PopupManager.Show ("Out of doubling counters.");
			throw new InvalidOperationException();
		}

		var tiledata = activePlayer.Get (this, q, r);

		// Check if the tile has already been doubled
		if (tiledata.IsDoubled)
		{
			PopupManager.Show ("Chosen tile has already been doubled.");
			throw new InvalidOperationException();
		}

		activePlayer.money -= tile.price;
		activePlayer.income += tile.incomeBonus;
		activePlayer.population += tile.populationBonus;
		activePlayer.reputation += tile.reputationBonus;

		activePlayer.doubleCounters--;

		// Double rule effect
		foreach (var rule in tile.rules)
		{
			rule.RunNow(this, activePlayer, tiledata);
		}

		// Set the tile as doubled in the HexGrid
		tiledata.IsDoubled = true;
		activePlayer.Set(this, q, r, tiledata.TileID, tiledata.IsDoubled);
	}
}
