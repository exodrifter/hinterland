using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public static partial class Util
{
	/// <summary>
	/// Returns true if the object is null or destroyed.
	/// </summary>
	/// <returns>
	/// <c>true</c> if the specified obj is null or destroyed.
	/// </returns>
	/// <param name="obj">The object to check.</param>
	public static bool IsNull(object obj)
	{
		return obj == null || obj.Equals(null);
	}

	/// <summary>
	/// Returns the hash for multiple objects.
	/// </summary>
	/// <returns>The hash for multiple objects.</returns>
	/// <param name="args">The objects to hash.</param>
	public static int GetHash(params object[] args)
	{
		unchecked
		{
			int hash = 17;
			foreach (var arg in args)
			{
				hash *= 23;
				if (!IsNull(arg))
				{
					hash += arg.GetHashCode();
				}
			}
			return hash;
		}
	}

	public static T Raycast<T>() where T : Component
	{
		// Do a graphics ray cast and physics raycast
		// because the UI System doesn't work with colliders
		var canvas = GameObject.FindObjectOfType<Canvas> ();
		GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
		PointerEventData ped = new PointerEventData(null);
		ped.position = Input.mousePosition;
		List<RaycastResult> results = new List<RaycastResult>();

		gr.Raycast (ped, results);

		if (results.Count != 0)
		{
			for (int i = 0; i < results.Count; i++)
			{				
				T comp = results [i].gameObject.GetComponent<T> ();

				if (!IsNull (comp))
				{
					return comp;
				}
			}
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100))
		{
			return hit.collider.gameObject.GetComponent<T> ();
		}

		return null;
	}
}
