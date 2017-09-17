using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
	private new Camera camera;

	public enum AnchorType {North, West, South, East, NorthWest, NorthEast, SouthWest, SouthEast}
	public AnchorType type = AnchorType.North;
	public Vector3 offset;

	void Awake()
	{
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		Vector3 position;
		Vector3 screenPosition;
		switch (type)
		{
			case AnchorType.North:
				screenPosition = new Vector3 (Screen.width / 2, Screen.height, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;

			case AnchorType.South:
				screenPosition = new Vector3 (Screen.width / 2, 0, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;

			case AnchorType.West:
				screenPosition = new Vector3 (Screen.width, Screen.height / 2, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;

			case AnchorType.East:
				screenPosition = new Vector3 (0, Screen.height / 2, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;

			case AnchorType.NorthWest:
				screenPosition = new Vector3 (Screen.width, Screen.height, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;
			
			case AnchorType.NorthEast:
				screenPosition = new Vector3 (0, Screen.height, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;
			
			case AnchorType.SouthWest:
				screenPosition = new Vector3 (Screen.width, 0, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;

			case AnchorType.SouthEast:
				screenPosition = new Vector3 (0, 0, 1);
				position = camera.ScreenToWorldPoint (screenPosition);
				break;

			default:
				position = new Vector3(0, 0, 0);
				break;
		}

		offset = offset + position;
	}
}
