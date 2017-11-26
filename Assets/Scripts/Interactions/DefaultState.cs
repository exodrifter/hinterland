using UnityEngine;
public class DefaultState : State
{
	// Update is called once per frame
	public override void Update (Interaction inter)
	{
		base.Update (inter);
		if (Input.GetMouseButtonDown(0))
		{
			MarketHex hex = Util.Raycast<MarketHex> ();
			if (!Util.IsNull (hex))
			{
				inter.PushState (new PurchaseState(hex));
			}

			// add double
		}
	}
}
