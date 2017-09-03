using UnityEngine;

public class PlayerMat : MonoBehaviour
{
	[SerializeField]
	private GameManager manager;

	[SerializeField]
	private int playerIndex = 0;

	[SerializeField]
	private Pool pool;

	void Update()
	{
		if (Util.IsNull(manager))
		{
			return;
		}

		// Get the map and draw it
		var player = manager.Game.players[playerIndex];
		var tiles = player.GetTileData(manager.Game);

		pool.DespawnAll();
		foreach (var tile in tiles)
		{
			var go = pool.Spawn();

			// Calculate position
			go.transform.position = tile.GetPosition();

			// Set Material/Texture
		}
		pool.UpdateActiveState();
	}
}
