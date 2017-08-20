public class CityRule : Rule
{
	public override void RunNow(Game game, Player player, TileData self)
	{
		Tile[] tiles = player.GetTiles(game);

		foreach (var tile in tiles)
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
		if (self.Player == other.Player)
		{
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