/// <summary>
/// Represents a tile in the game world.
/// </summary>
public class TileData : Tile
{
	/// <summary>
	/// The player that owns this tile.
	/// </summary>
	public Player Player
	{
		get { return player; }
	}
	private Player player;

	/// <summary>
	/// The tile metadata ID of this tile.
	/// </summary>
	public int TileID
	{
		get { return tileID; }
	}
	private int tileID;

	/// <summary>
	/// The localization data for this tile.
	/// </summary>
	public TileLocalization Localization
	{
		get { return localization; }
	}
	private TileLocalization localization;

	/// <summary>
	/// The Q position of this tile in the hex grid.
	/// </summary>
	public int Q
	{
		get { return q; }
	}
	private int q;

	/// <summary>
	/// The R position of this tile in the hex grid.
	/// </summary>
	public int R
	{
		get { return r; }
	}
	private int r;

	/// <summary>
	/// Gets a value indicating whether this instance is doubled.
	/// </summary>
	/// <value><c>true</c> if this instance is doubled; otherwise, <c>false</c>.</value>
	public bool IsDoubled
	{
		get { return isDoubled; }
		set { isDoubled = value; }
	}
	private bool isDoubled;

	public TileData(Tile tile, Player player, int tileID, TileLocalization localization, int q, int r, bool isDoubled)
		: base(tile)
	{
		this.player = player;
		this.tileID = tileID;
		this.localization = localization;
		this.q = q;
		this.r = r;
		this.isDoubled = isDoubled;
	}
}
