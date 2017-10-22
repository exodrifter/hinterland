using UnityEngine;

public class InvisibleHex : MonoBehaviour
{
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
}
