using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	public static Tooltip Instance { get; private set; }

	public void Awake()
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

	public static void SetTooltip(Vector2 screenPos, string tooltip)
	{
		if (string.IsNullOrEmpty(tooltip))
		{
			Instance.gameObject.SetActive(false);
		}
		else
		{
			Instance.gameObject.SetActive(true);
			Instance.transform.GetChild(0).transform.position = screenPos;
			Instance.GetComponentInChildren<Text>().text = tooltip;
		}
	}
}
