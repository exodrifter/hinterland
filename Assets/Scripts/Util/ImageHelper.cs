using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ImageHelper : MonoBehaviour {

	private static ImageHelper instance;

	private static void Initialize()
	{
		if (Util.IsNull(instance))
		{
			var gameobj = new GameObject ();
			instance = gameobj.AddComponent<ImageHelper>();
			DontDestroyOnLoad (gameobj);
			gameobj.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	public static void LoadImage(string file, Action<Texture> act)
	{
		Initialize();
		instance.BeginLoad(file, act);
	}

	private void BeginLoad(string file, Action<Texture> act)
	{
		StartCoroutine(LoadImageInternal(file, act));
	}

	private IEnumerator LoadImageInternal(string file, Action<Texture> act)
	{
		var path = Path.Combine(Application.streamingAssetsPath, file);
		WWW request = new WWW("file://" + path);

		yield return request;

		var texture = request.texture;
		texture.filterMode = FilterMode.Point;
		act (texture);
	}
}
