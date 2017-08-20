using System;

public enum HexDirection
{
	North,
	South,
	NorthEast,
	SouthEast,
	NorthWest,
	SouthWest,
}

public static class HexDirectionExtensions
{
	public static int GetDQ(this HexDirection direction)
	{
		switch (direction)
		{
			case HexDirection.SouthEast:
			case HexDirection.NorthEast:
				return 1;
			case HexDirection.North:
			case HexDirection.South:
				return 0;
			case HexDirection.NorthWest:
			case HexDirection.SouthWest:
				return -1;

			default:
				throw new InvalidOperationException();
		}
	}

	public static int GetDR(this HexDirection direction)
	{
		switch (direction)
		{
			case HexDirection.South:
			case HexDirection.SouthWest:
				return 1;
			case HexDirection.NorthWest:
			case HexDirection.SouthEast:
				return 0;
			case HexDirection.North:
			case HexDirection.NorthEast:
				return -1;

			default:
				throw new InvalidOperationException();
		}
	}
}
