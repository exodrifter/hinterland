using UnityEngine;
using UnityEngine.UI;

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
				tooltip.gameObject.SetActive (true);
				tooltip.transform.GetChild(0).transform.position = Input.mousePosition;
				tooltip.GetComponentInChildren<Text> ().text = desc.text;
			}
			else
			{
				tooltip.gameObject.SetActive (false);
			}
		}
		else
		{
			tooltip.gameObject.SetActive (false);
		}
	}
}
