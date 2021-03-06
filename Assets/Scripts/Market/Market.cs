﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	public Pool pool;

	private List<int> onSale = new List<int>();

	public void Update()
	{
		pool.DespawnAll();

		while (onSale.Count < 7)
		{
			var newTile = DrawTile();
			if (newTile == null)
			{
				break;
			}
			onSale.Add(newTile.Value);
		}

		pool.DespawnAll();

		for (int i = onSale.Count - 1; i >= 0; i--)
		{
			var tileID = onSale[i];

			var go = pool.Spawn();
			go.GetComponentInChildren<HexMaskRenderer>().SetTileID(tileID);

			var marketHex = go.GetComponentInChildren<MarketHex>();
			marketHex.tileID = tileID;
			marketHex.marketIndex = i;
			marketHex.market = this;
			go.GetComponentInChildren<TooltipInfo>().text = manager.Game.pack.GetTileLocalization()[tileID].desc;
		}

		pool.UpdateActiveState();
	}

	private int? DrawTile()
	{
		var stack = GetNextStack();

		if (stack == null)
		{
			return null;
		}

		// Calculate probability
		int total = 0;
		List<int> tileIDs = new List<int>(); // A (3), B (5), C (2)
		List<int> amount = new List<int>(); // { 3, 8, 10 }
		foreach (var kvp in stack.counts)
		{
			tileIDs.Add(kvp.Key);

			total += kvp.Value;
			amount.Add(total);
		}

		// Select a tile
		var selection = UnityEngine.Random.Range(0, total);
		for (int i = 0; i < amount.Count; ++i)
		{
			if (selection < amount[i])
			{
				var id = tileIDs[i];
				stack.counts[id]--;

				return id;
			}
		}

		return null;
	}

	private MarketStack GetNextStack()
	{
		// Remove all keys from market stacks with negative or zero counts
		foreach (var i in manager.Game.pack.GetMarketStacks())
		{
			List<int> toRemove = new List<int> ();
			foreach (var key in i.counts.Keys)
			{
				if (i.counts[key] <= 0)
				{
					toRemove.Add (key);
				}
			}

			foreach (var key in toRemove)
			{
				i.counts.Remove (key);
			}
		}

		// Get the first stack with a non-zero amount of tiles
		var stacks = manager.Game.pack.GetMarketStacks();
		for (int i = 0; i < stacks.Length; ++i)
		{
			var stack = stacks[i];
			if (stack.counts.Count != 0)
			{
				return stack;
			}
		}

		return null;
	}

	public void Remove(int marketIndex)
	{
		onSale.RemoveAt(marketIndex);
	}
}
