using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float cameraSpeed;

	// Update is called once per frame
	void Update ()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * cameraSpeed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * cameraSpeed;

		transform.Translate(x, y, 0);
	}
}
