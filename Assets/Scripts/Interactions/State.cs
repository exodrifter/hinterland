using UnityEngine;

public abstract class State
{	
	public virtual void Update(Interaction inter)
	{
		var tooltip = Tooltip.Instance;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100))
		{
			TooltipInfo desc = hit.collider.gameObject.GetComponent<TooltipInfo> ();
			if (!Util.IsNull (desc))
			{
				Tooltip.SetTooltip(Input.mousePosition, desc.text);
			}
			else
			{
				Tooltip.SetTooltip(Vector2.zero, null);
			}
		}
		else
		{
			Tooltip.SetTooltip(Vector2.zero, null);
		}
	}
}
