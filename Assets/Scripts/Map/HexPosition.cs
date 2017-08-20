public class HexPosition
{
	public int q;
	public int r;

	public HexPosition(int q, int r)
	{
		this.q = q;
		this.r = r;
	}

	public override bool Equals(object obj)
	{
		if (obj is HexPosition)
		{
			var other = (HexPosition)obj;
			return other.q == q && other.r == r;
		}

		return false;
	}

	public override int GetHashCode()
	{
		return Util.GetHash(q, r);
	}
}
