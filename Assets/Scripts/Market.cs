using UnityEngine;

public class Market : MonoBehaviour
{
	public Pool pool;

	public int[] tiles = new int[] { 0, 1, 2 };

	public void Update()
	{
		pool.DespawnAll();

		for (int i = 0; i < tiles.Length; ++i)
		{
			var go = pool.Spawn();
			go.GetComponent<Anchor>().offset = new Vector3(1.2f, -1 - i * 2, 1);
			go.GetComponent<HexRenderer>().SetTileID(tiles[i]);
		}

		pool.UpdateActiveState();
	}
}
