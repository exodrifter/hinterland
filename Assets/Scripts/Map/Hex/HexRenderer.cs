using UnityEngine;

public class HexRenderer : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	public void SetTileID(int tileID)
	{
		var file = manager.Game.localization[tileID].file;
		var renderer = GetComponent<MeshRenderer>();
		ImageHelper.LoadImage (file, (tex) => {renderer.material.SetTexture("_MainTex", tex);});
	}
}
