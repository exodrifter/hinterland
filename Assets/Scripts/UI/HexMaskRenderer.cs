using UnityEngine;
using UnityEngine.UI;

public class HexMaskRenderer : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	public void SetTileID(int tileID)
	{
		var file = manager.Game.pack.GetTilePath(tileID);
		ImageHelper.LoadImage(file, (tex) => {
			var sprite = Sprite.Create((Texture2D)tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
			GetComponent<Image>().sprite = sprite;
		});
	}
}
