using UnityEngine;
public abstract class State
{
//	public abstract void Update (Interaction inter);
	
	public virtual void Update(Interaction inter)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100))
		{
			Description desc = hit.collider.gameObject.GetComponent<Description> ();
			if (!Util.IsNull (desc))
			{
				MarketHex hex = hit.collider.gameObject.GetComponent<MarketHex> ();
				desc.tileID = hex.tileID;
				desc.show = true;
			}
		}
	}
}
