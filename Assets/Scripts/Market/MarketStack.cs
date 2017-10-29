using System;
using System.Collections.Generic;

[Serializable]
public class MarketStack
{
	public Dictionary<int, int> counts = new Dictionary<int, int>();

	public MarketStack()
	{
		counts[0] = 1;
	}
}
