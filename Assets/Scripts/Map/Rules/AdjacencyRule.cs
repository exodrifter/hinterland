public class AdjacencyRule : Rule
{
	public override void RunNow(Game game, Player player, TileData self)
	{
		Tile[] neighbors = player.GetNeighbors(game, self.Q, self.R);

		types = types ?? new System.Collections.Generic.List<TypeIcon>();
		specialties = specialties ?? new System.Collections.Generic.List<SpecialtyIcon>();

		foreach (var tile in neighbors)
		{
			if (types.Contains(tile.typeIcon)
				|| specialties.Contains(tile.specialtyIcon))
			{
				player.income += incomeBonus;
				player.reputation += reputationBonus;
				player.money += moneyBonus;
				player.population += populationBonus;
			}
		}
	}

	public override void RunUpdate(Game game, Player player, TileData self, TileData other)
	{
		if (HexGrid.IsAdjacent(self.Q, self.R, other.Q, other.R))
		{
			types = types ?? new System.Collections.Generic.List<TypeIcon>();
			specialties = specialties ?? new System.Collections.Generic.List<SpecialtyIcon>();

			if (types.Contains(other.typeIcon)
				|| specialties.Contains(other.specialtyIcon))
			{
				player.income += incomeBonus;
				player.reputation += reputationBonus;
				player.money += moneyBonus;
				player.population += populationBonus;
			}
		}
	}
}