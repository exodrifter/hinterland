using UnityEngine;

public class Market : MonoBehaviour
{
	public Pool pool;

	public void Update()
	{
		pool.DespawnAll();

		for (int i = 0; i < 3; ++i)
		{
			var go = pool.Spawn();
			go.GetComponent<Anchor>().offset = new Vector3(1.2f, -1 - i * 2, 1);
		}

		pool.UpdateActiveState();
	}
}
