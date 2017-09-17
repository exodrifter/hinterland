using Newtonsoft.Json;
using System.Collections;
using System.IO;
using UnityEngine;

public class PlayerMat : MonoBehaviour
{
	[SerializeField]
	private GameManager manager;

	[SerializeField]
	private int playerIndex = 0;

	[SerializeField]
	private Pool pool;

	private TileLocalization[] localization;

	void Awake()
	{
		localization = LoadLocalization ();
	}

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
			var file = localization[tile.TileID].file;
			StartCoroutine(LoadImage(file, go.GetComponent<MeshRenderer>()));
		}
		pool.UpdateActiveState();
	}

	private TileLocalization[] LoadLocalization()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(
			Path.Combine(Application.streamingAssetsPath, "suburbia-english.json"));
		return JsonConvert.DeserializeObject<TileLocalization[]>(metadataJson, settings);
	}

	private IEnumerator LoadImage(string file, MeshRenderer renderer)
	{
		var path = Path.Combine (Application.streamingAssetsPath, file);
		WWW request = new WWW ("file://" + path);

		yield return request;

		var texture = request.texture;
		texture.filterMode = FilterMode.Point;
		renderer.material.SetTexture ("_MainTex", texture);
	}
}
