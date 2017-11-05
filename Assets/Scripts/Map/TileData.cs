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

	public string TileName
	{
		get { return tileName; }
	}
	private string tileName;

	public string Description
	{
		get { return desc; }
	}
	private string desc;

	public TileData(Tile tile, Player player, int tileID, string name, string desc, int q, int r)
		: base(tile)
	{
		this.player = player;
		this.tileID = tileID;
		this.tileName = name;
		this.desc = desc;
		this.q = q;
		this.r = r;
	}
}
