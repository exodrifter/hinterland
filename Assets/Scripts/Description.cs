using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Description : MonoBehaviour
{
	[SerializeField]
	private GameManager manager;

	public int tileID;
	public bool show = false;

	public GameObject tooltip;

	public Text tileDesc;

	// Update is called once per frame
	void Update ()
	{
		if (show)
		{
//			tooltip.SetActive (true);
			tooltip.transform.position = Input.mousePosition;

			tileDesc.text = manager.Game.localization[tileID].desc;
			Debug.Log (manager.Game.localization[tileID].desc);
		}
//		tooltip.SetActive (false);
		show = false;
	}
}
