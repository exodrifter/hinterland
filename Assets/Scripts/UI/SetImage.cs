using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
	void Awake()
	{
		ImageHelper.LoadImage("suburbia/community-park.png", (tex) => {
			var sprite = Sprite.Create((Texture2D)tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
			GetComponent<Image>().sprite = sprite;
		});
	}
}
