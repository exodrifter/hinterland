using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	public static Tooltip Instance { get; private set; }

	public RectTransform panel;
	public Text tooltip;

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
			Instance.tooltip.text = tooltip;

			SetPosition(screenPos);
		}
	}

	private static void SetPosition(Vector2 screenPos)
	{
		var rightOffset = new Vector2(10, 0);
		var flip = true;

		var size = Instance.panel.sizeDelta;
		if (screenPos.x + size.x + rightOffset.x > Screen.width)
		{
			flip = false;
		}

		// Tooltip on the right
		if (flip)
		{
			Instance.panel.pivot = new Vector2(0, 1);
			Instance.panel.position = screenPos + rightOffset;
		}
		// Tooltip on the left
		else
		{
			Instance.panel.pivot = new Vector2(1, 1);
			Instance.panel.position = screenPos;
		}
	}
}
