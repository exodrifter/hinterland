using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Game Game
	{
		get { return game; }
	}
	private Game game;

	public void Awake()
	{
		game = new Game();
		game.metadata = LoadMetadata();
		game.marketStacks = LoadMarketStacks();

		var player = new Player();
		player.money = 20;
		game.players.Add(player);
		game.activePlayer = player;

		game.PlaceTile(0, 0, 0);
		game.PlaceTile(1, 0, 1);
		game.PlaceTile(2, 0, 2);
	}

	private Tile[] LoadMetadata()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(
				Path.Combine(Application.streamingAssetsPath, "metadata.json"));
		return JsonConvert.DeserializeObject<Tile[]>(metadataJson, settings);
	}

	private MarketStack[] LoadMarketStacks()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(
				Path.Combine(Application.streamingAssetsPath, "suburbia-market.json"));
		return JsonConvert.DeserializeObject<MarketStack[]>(metadataJson, settings);
	}
}
