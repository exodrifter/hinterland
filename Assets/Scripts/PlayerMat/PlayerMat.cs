using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMat : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	[SerializeField]
	private int playerIndex = 0;

	[SerializeField]
	private Pool pool;

	[SerializeField]
	private Pool invisible;

	void Update()
	{
		if (Util.IsNull(manager))
		{
			return;
		}

		// Get the map and draw it
		var player = manager.Game.players[playerIndex];
		var tiles = player.GetTileData(manager.Game);

		// Show tiles
		pool.DespawnAll();
		foreach (var tile in tiles)
		{
			var go = pool.Spawn();

			// Calculate position
			go.transform.position = Hex.GetPosition(tile.Q, tile.R);

			// Set Material/Texture
			go.GetComponent<HexRenderer>().SetTileID(tile.TileID);

			// Set tooltip
			go.GetComponent<TooltipInfo>().text = manager.Game.pack.GetTileLocalization()[tile.TileID].desc;

			// Set Clickable Hex Post
			var click = go.GetComponent<ClickableHex>();
			click.TileID = tile.TileID;
			click.Q = tile.Q;
			click.R = tile.R;
			click.Visible = true;
		}
		pool.UpdateActiveState();

		// Draw invisible tiles
		HashSet<HexPosition> usedPositions = new HashSet<HexPosition>();
		invisible.DespawnAll();
		foreach (var tile in tiles)
		{
			var game = manager.Game;

			var q = tile.Q;
			var r = tile.R;

			foreach (var dir in Enum.GetValues(typeof(HexDirection)))
			{
				var d = (HexDirection)dir;

				var nq = q + d.GetDQ();
				var nr = r + d.GetDR();

				if (game.activePlayer.HasAt(nq, nr))
				{
					continue;
				}

				var newPos = new HexPosition(nq, nr);
				if (usedPositions.Contains(newPos))
				{
					continue;
				}
				usedPositions.Add(newPos);

				var go = invisible.Spawn();
				go.transform.position = Hex.GetPosition(nq, nr);

				var click = go.GetComponent<ClickableHex>();
				click.TileID = -1;
				click.Q = nq;
				click.R = nr;
				click.Visible = false;
			}
		}

		invisible.UpdateActiveState();
	}
}
