using UnityEngine;
using UnityEngine.UI;

public class HexMaskRenderer : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	private string cachedFile;
	private Sprite cachedSprite;

	public void SetTileID(int tileID)
	{
		var file = manager.Game.pack.GetTilePath(tileID);

		if (cachedFile != file)
		{
			cachedFile = file;
			if (!Util.IsNull(cachedSprite))
			{
				Destroy(cachedSprite);
			}

			ImageHelper.LoadImage(file, (tex) =>
			{
				cachedSprite = Sprite.Create((Texture2D)tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
				GetComponent<Image>().sprite = cachedSprite;
			});
		}
	}
}
