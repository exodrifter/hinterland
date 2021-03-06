﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseState : State
{
	private MarketHex marketHex;

	public PurchaseState(MarketHex marketHex)
	{
		this.marketHex = marketHex;
	}

	// Update is called once per frame
	public override void Update (Interaction inter)
	{
		base.Update (inter);
		if (Input.GetMouseButtonDown(0))
		{
			ClickableHex hex = Util.Raycast<ClickableHex> ();
			if (!Util.IsNull (hex))
			{
				// Place it
				try
				{
					if (!hex.Visible)
					{
						inter.gm.Game.PlaceTile(marketHex.tileID, hex.Q, hex.R, marketHex.marketIndex);
						marketHex.RemoveFromMarket();
					}
				}
				// Go back to the previous state
				finally
				{
					inter.PopState();
				}
			}
		}
	}
}
