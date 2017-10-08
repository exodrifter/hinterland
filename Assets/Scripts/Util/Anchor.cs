using UnityEngine;

public class Anchor : MonoBehaviour
{
	private new Camera camera;

	public enum AnchorType { North, West, South, East, NorthWest, NorthEast, SouthWest, SouthEast }
	public AnchorType type = AnchorType.North;
	public Vector3 offset;

	void Awake()
	{
		camera = Camera.main;
	}

	void Update()
	{
		Vector3 position = Vector3.zero;
		switch (type)
		{
			case AnchorType.North:
				position = new Vector3(Screen.width / 2, Screen.height, 0);
				break;

			case AnchorType.South:
				position = new Vector3(Screen.width / 2, 0, 0);
				break;

			case AnchorType.West:
				position = new Vector3(0, Screen.height / 2, 0);
				break;

			case AnchorType.East:
				position = new Vector3(Screen.width, Screen.height / 2, 0);
				break;

			case AnchorType.NorthWest:
				position = new Vector3(0, Screen.height, 0);
				break;

			case AnchorType.NorthEast:
				position = new Vector3(Screen.width, Screen.height, 0);
				break;

			case AnchorType.SouthWest:
				position = new Vector3(0, 0, 0);
				break;

			case AnchorType.SouthEast:
				position = new Vector3(Screen.width, 0, 0);
				break;
		}

		position = camera.ScreenToWorldPoint(position);
		transform.position = offset + position;
	}
}
