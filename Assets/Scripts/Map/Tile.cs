using System;

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

	public Tile()
	{

	}

	public Tile(Tile tile)
	{
		this.price = tile.price;
		this.populationBonus = tile.populationBonus;
		this.reputationBonus = tile.reputationBonus;
		this.incomeBonus = tile.incomeBonus;
		this.typeIcon = tile.typeIcon;
		this.specialtyIcon = tile.specialtyIcon;

		rules = new Rule[tile.rules.Length];
		for (int i = 0; i < tile.rules.Length; i++)
		{
			rules[i] = tile.rules[i];
		}
	}
}