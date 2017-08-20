using System;
using System.Collections.Generic;

[Serializable]
public abstract class Rule
{
	public int incomeBonus;
	public int reputationBonus;
	public int moneyBonus;
	public int populationBonus;

	public List<TypeIcon> types;
	public List<SpecialtyIcon> specialties;

	/// <summary>
	/// Applies the rule for the tile when the tile has been placed.
	/// </summary>
	/// <param name="player">The player who placed the tile.</param>
	/// <param name="self">The data of the tile that was placed.</param>
	public abstract void RunNow(Game game, Player player, TileData self);

	/// <summary>
	/// Applies the rule for the tile when another tile has been placed.
	/// </summary>
	/// <param name="player">The player who placed the tile.</param>
	/// <param name="self">The data of the tile.</param>
	/// <param name="other">The data of the tile that was placed.</param>
	public abstract void RunUpdate(Game game, Player player, TileData self, TileData other);
}
