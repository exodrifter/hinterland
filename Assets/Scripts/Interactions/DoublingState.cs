using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublingState : State
{
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
					if (hex.Visible)
					{
						inter.gm.Game.DoubleTile(hex.Q, hex.R);
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
