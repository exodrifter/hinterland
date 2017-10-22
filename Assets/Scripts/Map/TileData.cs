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

	public TileData(Tile tile, Player player, int tileID, int q, int r)
		: base(tile)
	{
		this.player = player;
		this.tileID = tileID;
		this.q = q;
		this.r = r;
	}
}
