using System;
using UnityEngine;

[Serializable]
public class Factory
{
	[SerializeField]
	private Transform parent;
	[SerializeField]
	private GameObject prefab;

	public Factory(Transform parent, GameObject prefab)
	{
		this.parent = parent;
		this.prefab = prefab;
	}

	public GameObject Instantiate()
	{
		var ret = UnityEngine.Object.Instantiate(prefab);
		ret.transform.SetParent(parent, false);
		return ret;
	}
}
