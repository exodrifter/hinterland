using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
	public Text errorMessage;
	
	public void SetMessage(string message)
	{
		errorMessage.text = message;
	}

	public void ClosePopup()
	{
		PopupManager.Instance.popupPool.Despawn(this.gameObject);
		PopupManager.Instance.popupPool.UpdateActiveState();
	}
}
