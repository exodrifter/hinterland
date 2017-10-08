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
		var renderer = GetComponent<MeshRenderer>();
		ImageHelper.LoadImage (file, (tex) => {renderer.material.SetTexture("_MainTex", tex);});
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
