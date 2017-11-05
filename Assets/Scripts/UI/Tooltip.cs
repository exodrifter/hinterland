using UnityEngine;

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
}
