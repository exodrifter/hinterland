using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class Test : MonoBehaviour
{
	public Game game;

	void Start()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		game = new Game();

		var metadataJson = File.ReadAllText(
				Path.Combine(Application.streamingAssetsPath, "metadata.json"));
		game.metadata = JsonConvert.DeserializeObject<Tile[]>(metadataJson, settings);

		var player = new Player();
		player.money = 15;

		game.players.Add(player);
		game.activePlayer = player;

		game.PlaceTile(game.metadata[0], 0, 0);
	}

	private void Update()
	{
	}
}
