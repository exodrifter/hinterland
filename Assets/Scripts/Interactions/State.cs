using UnityEngine;

public abstract class State
{	
	public virtual void Update(Interaction inter)
	{
		var tooltip = Tooltip.Instance;

		TooltipInfo desc = Util.Raycast<TooltipInfo> ();
		if (!Util.IsNull (desc))
		{
			Tooltip.SetTooltip(Input.mousePosition, desc.text);
		}
		else
		{
			Tooltip.SetTooltip(Vector2.zero, null);
		}
	}
}
