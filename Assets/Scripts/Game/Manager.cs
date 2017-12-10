using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
	public Game Game
	{
		get { return game; }
	}
	private Game game;

	public void Awake()
	{
		game = new Game();
		game.pack = GamePack.LoadPack(Path.Combine(Application.streamingAssetsPath, "suburbia"));
		game.pack.SetLanguage("spa");

		var player = new Player();
		player.money = 20;
		game.players.Add(player);
		game.activePlayer = player;

		game.PlaceTile(0, 0, 0);
		game.PlaceTile(1, 0, 1);
		game.PlaceTile(2, 0, 2);
	}
}
