using UnityEngine;

public static class Hex
{
	/// <summary>
	/// The size of the hexes.
	/// </summary>
	private const float DEFAULT_SIZE = 1f;

	public static Vector3 GetPosition(float q, float r, float size = DEFAULT_SIZE)
	{
		var x = size * 3f / 2f * q;
		var y = size * Mathf.Sqrt(3f) * (r + q / 2f);
		return new Vector3(x, y, 0);
	}
}
