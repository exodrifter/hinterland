using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
	public Pool popupPool;

	public static PopupManager Instance { get; private set; }

	private void Awake()
	{
		if (Util.IsNull (Instance))
		{
			Instance = this;
		}
		else
		{
			Destroy (this);
		}
	}

	public static void Show(string message)
	{
		var go = Instance.popupPool.Spawn ();
		go.GetComponent<PopupController> ().SetMessage(message);
		Instance.popupPool.UpdateActiveState ();
	}
}
