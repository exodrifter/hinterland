using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
	[SerializeField]
	private Factory factory;

	private List<GameObject> pooled = new List<GameObject>();
	private List<GameObject> spawned = new List<GameObject>();

	public void DespawnAll()
	{
		foreach (var go in spawned)
		{
			pooled.Add(go);
		}

		spawned.Clear();
	}

	public GameObject Spawn()
	{
		GameObject go;

		if (pooled.Count == 0)
		{
			go = factory.Instantiate();
		}
		else
		{
			go = pooled[pooled.Count - 1];
			pooled.RemoveAt(pooled.Count - 1);
		}

		spawned.Add(go);
		return go;
	}

	public void UpdateActiveState()
	{
		foreach (var go in pooled)
		{
			go.SetActive(false);
		}
		foreach (var go in spawned)
		{
			go.SetActive(true);
		}
	}
}
