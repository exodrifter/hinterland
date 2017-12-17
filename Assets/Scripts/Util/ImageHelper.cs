using System.Collections;
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class ImageHelper : MonoBehaviour
{
	private static ImageHelper instance;

	private Dictionary<string, Texture> cachedTextures = new Dictionary<string, Texture>();

	private static void Initialize()
	{
		if (Util.IsNull(instance))
		{
			var gameobj = new GameObject();
			instance = gameobj.AddComponent<ImageHelper>();
			DontDestroyOnLoad(gameobj);
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
		// StartCoroutine is expensive
		cachedTextures = cachedTextures ?? new Dictionary<string, Texture>();
		if (cachedTextures.ContainsKey(file)) {
			act(cachedTextures[file]);
			return;
		}

		StartCoroutine(LoadImageInternal(file, act));
	}

	private IEnumerator LoadImageInternal(string file, Action<Texture> act)
	{
		cachedTextures = cachedTextures ?? new Dictionary<string, Texture>();
		if (!cachedTextures.ContainsKey(file))
		{
			var path = Path.Combine(Application.streamingAssetsPath, file);
			WWW request = new WWW("file://" + path);

			yield return request;

			var texture = request.texture;
			texture.filterMode = FilterMode.Point;
			cachedTextures[file] = texture;
		}

		act(cachedTextures[file]);
	}
}
