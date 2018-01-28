using UnityEngine;

public class ClickableHex : MonoBehaviour
{
	public int TileID
	{
		get { return tileID; }
		set { tileID = value; }
	}
	private int tileID;

	public int Q
	{
		get { return q; }
		set { q = value; }
	}
	[SerializeField]
	private int q;

	public int R
	{
		get { return r; }
		set { r = value; }
	}
	[SerializeField]
	private int r;

	public bool Visible
	{
		get { return visible; }
		set { visible = value; }
	}
	[SerializeField]
	private bool visible;
}
