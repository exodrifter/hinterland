public class TileData : Tile
{
	public Player Player
	{
		get { return player; }
	}
	private Player player;

	public int TileID
	{
		get { return tileID; }
	}
	private int tileID;

	public int Q
	{
		get { return q; }
	}
	private int q;

	public int R
	{
		get { return r; }
	}
	private int r;

	public TileLocalization Localization
	{
		get { return localization; }
	}
	private TileLocalization localization;

	public TileData(Tile tile, Player player, int tileID, TileLocalization localization, int q, int r)
		: base(tile)
	{
		this.player = player;
		this.tileID = tileID;
		this.localization = localization;
		this.q = q;
		this.r = r;
	}
}
