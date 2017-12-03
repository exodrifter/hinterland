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

	public void Despawn(GameObject go)
	{
		if (spawned.Remove (go))
		{
			pooled.Add (go);
		}
	}

	public void DespawnAll()
	{
		for (int i = spawned.Count - 1; i >= 0; --i)
		{
			pooled.Add(spawned[i]);
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
