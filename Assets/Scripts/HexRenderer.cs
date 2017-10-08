using Newtonsoft.Json;
using System.Collections;
using System.IO;
using UnityEngine;

public class HexRenderer : MonoBehaviour
{
	private TileLocalization[] localization;

	public void SetTileID(int tileID)
	{
		if (localization == null)
		{
			localization = LoadLocalization();
		}

		var file = localization[tileID].file;
		StartCoroutine(LoadImage(file, GetComponent<MeshRenderer>()));
	}

	private IEnumerator LoadImage(string file, MeshRenderer renderer)
	{
		var path = Path.Combine(Application.streamingAssetsPath, file);
		WWW request = new WWW("file://" + path);

		yield return request;

		var texture = request.texture;
		texture.filterMode = FilterMode.Point;
		renderer.material.SetTexture("_MainTex", texture);
	}

	private TileLocalization[] LoadLocalization()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(
			Path.Combine(Application.streamingAssetsPath, "suburbia-english.json"));
		return JsonConvert.DeserializeObject<TileLocalization[]>(metadataJson, settings);
	}
}
