using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicking : MonoBehaviour
{
		
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100))
			{
				Debug.Log ("I am clicking on " + hit.collider.transform.tag + " tile!");

				if (hit.collider.transform.tag == "Market")
				{
					
				} else if (hit.collider.transform.tag == "PlayerBoard")
				{
					
				}
			}
		}
	}
}
