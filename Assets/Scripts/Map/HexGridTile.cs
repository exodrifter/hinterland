/// <summary>
/// JSON representation of a tile in the hex grid.
/// </summary>
public class HexGridTile
{
	public int tileID;
	public bool isDoubled;

	public HexGridTile(int tileID, bool isDoubled)
	{
		this.tileID = tileID;
		this.isDoubled = isDoubled;
	}
}
