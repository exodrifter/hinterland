using UnityEngine;

public class MarketHex : MonoBehaviour
{
	public int tileID;
	public int marketIndex;
	public Market market;

	public void RemoveFromMarket()
	{
		market.Remove(marketIndex);
	}
}
