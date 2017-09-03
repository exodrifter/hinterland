using Newtonsoft.Json;
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

		var player = new Player();
		player.money = 20;
		game.players.Add(player);
		game.activePlayer = player;

		game.PlaceTile(game.metadata[0], 0, 0);
		game.PlaceTile(game.metadata[1], 1, 0);
	}

	private Tile[] LoadMetadata()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(
				Path.Combine(Application.streamingAssetsPath, "metadata.json"));
		return JsonConvert.DeserializeObject<Tile[]>(metadataJson, settings);
	}
}
