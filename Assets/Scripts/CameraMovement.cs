using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float keySpeed = 10;
	private Vector3? dragOrigin;

	void Update()
	{
		HandleMouse();
		HandleKeyboard();
	}

	private void HandleKeyboard()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * keySpeed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * keySpeed;
		transform.Translate(x, y, 0);
	}

	private bool HandleMouse()
	{
		// Start dragging
		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return true;
		}
		// Stop dragging
		if (!Input.GetMouseButton(0))
		{
			dragOrigin = null;
			return false;
		}

		// Calculate drag
		if (dragOrigin.HasValue)
		{
			var oldPos = ScreenToWorldPoint(dragOrigin.Value);
			var newPos = ScreenToWorldPoint(Input.mousePosition);
			transform.Translate(oldPos - newPos);

			dragOrigin = Input.mousePosition;
			return true;
		}

		return false;
	}

	#region Util

	private Vector3 ScreenToWorldPoint(Vector3 pos)
	{
		return Camera.main.ScreenPointToRay(pos).GetPoint(10);
	}

	#endregion
}
