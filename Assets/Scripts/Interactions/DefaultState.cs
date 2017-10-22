using UnityEngine;
public class DefaultState : State
{
	
	// Update is called once per frame
	public override void Update (Interaction inter)
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100))
			{
				MarketHex hex = hit.collider.gameObject.GetComponent<MarketHex> ();
				if (!Util.IsNull (hex))
				{
					inter.PushState (new PurchaseState(hex.tileID));
				}

				// add double
			}
		}
	}
}
