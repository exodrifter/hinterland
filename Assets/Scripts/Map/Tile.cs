using System;

/// <summary>
/// Represents the JSON data of a tile.
/// </summary>
[Serializable]
public class Tile
{
	/// <summary>
	/// The price of the tile.
	/// </summary>
	public int price;

	/// <summary>
	/// Flat population bonus received when placing tile.
	/// </summary>
	public int populationBonus;

	/// <summary>
	/// Flat reputation bonus received when placing tile.
	/// </summary>
	public int reputationBonus;

	/// <summary>
	/// Flat income bonus received when placing tile.
	/// </summary>
	public int incomeBonus;

	/// <summary>
	/// The type icon of this tile.
	/// </summary>
	public TypeIcon typeIcon;

	/// <summary>
	/// The specialty icon of this tile.
	/// </summary>
	public SpecialtyIcon specialtyIcon;

	/// <summary>
	/// The special rules of this tile.
	/// </summary>
	public Rule[] rules;

	public Tile() { rules = new Rule[0]; }

	public Tile(Tile tile)
	{
		price = tile.price;
		populationBonus = tile.populationBonus;
		reputationBonus = tile.reputationBonus;
		incomeBonus = tile.incomeBonus;
		typeIcon = tile.typeIcon;
		specialtyIcon = tile.specialtyIcon;

		rules = new Rule[tile.rules.Length];
		for (int i = 0; i < tile.rules.Length; i++)
		{
			rules[i] = tile.rules[i];
		}
	}
}