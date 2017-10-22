using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseState : State
{
	private int tileID;

	public PurchaseState(int tileID)
	{
		this.tileID = tileID;
	}

	// Update is called once per frame
	public override void Update (Interaction inter)
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100))
			{
				InvisibleHex hex = hit.collider.gameObject.GetComponent<InvisibleHex> ();
				if (!Util.IsNull (hex))
				{
					// Place it
					inter.gm.Game.PlaceTile (tileID, hex.Q, hex.R);

					// TODO: Remove from Market

					// Go back to the previous state
					inter.PopState();
				}
			}
		}
	}
}
