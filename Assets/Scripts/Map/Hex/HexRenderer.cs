using UnityEngine;

public class HexRenderer : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	public void SetTileID(int tileID)
	{
		var file = manager.Game.pack.GetTilePath(tileID);
		var renderer = GetComponent<MeshRenderer>();
		ImageHelper.LoadImage (file, (tex) => {renderer.material.SetTexture("_MainTex", tex);});
	}
}
