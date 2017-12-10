using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class GamePack
{
	/// <summary>
	/// The root path of this game pack.
	/// </summary>
	private string root;

	/// <summary>
	/// The desired ISO 639-2 language code.
	/// </summary>
	private string lang = "eng";

	/// <summary>
	/// References a game pack on disk.
	/// </summary>
	/// <param name="root">The root path of this game pack.</param>
	private GamePack(string root)
	{
		this.root = root;
	}

	/// <summary>
	/// Sets the desired localization for this pack.
	/// </summary>
	/// <param name="lang">The ISO 639-2 language code.</param>
	public void SetLanguage(string lang)
	{
		this.lang = lang;
	}

	/// <summary>
	/// Returns the tile metadata for this pack.
	/// </summary>
	/// <returns>The tile metadata.</returns>
	public Tile[] GetMetadata()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(Path.Combine(root, "metadata.json"));
		return JsonConvert.DeserializeObject<Tile[]>(metadataJson, settings);
	}

	/// <summary>
	/// Returns the default market stacks for this pack.
	/// </summary>
	/// <returns>The default market stacks.</returns>
	public MarketStack[] GetMarketStacks()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(Path.Combine(root, "market.json"));
		return JsonConvert.DeserializeObject<MarketStack[]>(metadataJson, settings);
	}

	/// <summary>
	/// Returns a list of supported ISO 639-2 language codes.
	/// </summary>
	/// <returns>A list of supported ISO 639-2 language codes.</returns>
	public string[] GetAvailableLocalizations()
	{
		string[] localizations = Directory.GetFiles(Path.Combine(root, "language"));

		for (int i = 0; i < localizations.Length; i++)
		{
			localizations[i] = Path.ChangeExtension(localizations[i], null);
		}

		return localizations;
	}

	/// <summary>
	/// Returns the specified localization for this pack.
	/// </summary>
	/// <returns>The localization for this pack.</returns>
	public TileLocalization[] GetLocalization()
	{
		var settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.All;

		var metadataJson = File.ReadAllText(Path.Combine(root, "language/" + lang + ".json"));
		return JsonConvert.DeserializeObject<TileLocalization[]>(metadataJson, settings);
	}

	public string GetTilePath(int tileID)
	{
		return Path.Combine(root, "img/" + GetLocalization()[tileID].file);
	}

	#region Static

	/// <summary>
	/// Returns a list of available packs.
	/// </summary>
	/// <returns>A list of available packs.</returns>
	public static string[] GetPacks()
	{
		return Directory.GetDirectories(Application.streamingAssetsPath);
	}

	/// <summary>
	/// Loads the specified pack.
	/// </summary>
	/// <param name="name">The name of the pack to load.</param>
	/// <returns>The pack.</returns>
	public static GamePack LoadPack(string path)
	{
		return new GamePack(path);
	}

	#endregion
}
