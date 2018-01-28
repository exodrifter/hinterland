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

	private Tile[] cachedMetadata = null;

	private MarketStack[] cachedMarketStacks = null;

	private string cachedTileLanguageString = null;
	private TileLocalization[] cachedTileLocalization = null;

	private string cachedMsgLanguageString = null;
	private MsgLocalization[] cachedMsgLocalization = null;

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
		if (cachedMetadata == null)
		{
			var settings = new JsonSerializerSettings();
			settings.TypeNameHandling = TypeNameHandling.All;

			var json = File.ReadAllText(Path.Combine(root, "metadata.json"));
			cachedMetadata = JsonConvert.DeserializeObject<Tile[]>(json, settings);
		}

		return cachedMetadata;
	}

	/// <summary>
	/// Returns the default market stacks for this pack.
	/// </summary>
	/// <returns>The default market stacks.</returns>
	public MarketStack[] GetMarketStacks()
	{
		if (cachedMarketStacks == null)
		{
			var settings = new JsonSerializerSettings();
			settings.TypeNameHandling = TypeNameHandling.All;

			var metadataJson = File.ReadAllText(Path.Combine(root, "market.json"));
			cachedMarketStacks = JsonConvert.DeserializeObject<MarketStack[]>(metadataJson, settings);
		}

		return cachedMarketStacks;
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
	public TileLocalization[] GetTileLocalization()
	{
		if (cachedTileLanguageString != lang)
		{
			cachedTileLanguageString = lang;

			var settings = new JsonSerializerSettings();
			settings.TypeNameHandling = TypeNameHandling.All;

			var metadataJson = File.ReadAllText(Path.Combine(root, "language/" + lang + "/" + "tile-" + lang + ".json"));
			cachedTileLocalization = JsonConvert.DeserializeObject<TileLocalization[]>(metadataJson, settings);
		}

		return cachedTileLocalization;
	}

	/// <summary>
	/// Returns the specified localization for this pack.
	/// </summary>
	/// <returns>The localization for this pack.</returns>
	public MsgLocalization[] GetMsgLocalization()
	{
		if (cachedMsgLanguageString != lang)
		{
			cachedMsgLanguageString = lang;

			var settings = new JsonSerializerSettings();
			settings.TypeNameHandling = TypeNameHandling.All;

			var metadataJson = File.ReadAllText(Path.Combine(root, "language/" + lang + "/" + "msg-catalog-" + lang + ".json"));
			cachedMsgLocalization = JsonConvert.DeserializeObject<MsgLocalization[]>(metadataJson, settings);
		}

		return cachedMsgLocalization;
	}


	public string GetTilePath(int tileID)
	{
		return Path.Combine(root, "img/" + GetTileLocalization()[tileID].file);
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
