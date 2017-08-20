public class GlobalRule : Rule
{
	public override void RunNow(Game game, Player _, TileData self)
	{
		foreach (var player in game.players)
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
	}

	public override void RunUpdate(Game game, Player player, TileData self, TileData other)
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