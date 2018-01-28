using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
	[SerializeField]
	private Manager manager;

	[SerializeField]
	private int playerIndex;

	public Text moneyText;
	public Text populationText;

	void Update ()
	{
		var player = manager.Game.players[playerIndex];

		// TODO: Localization
		var incomeSign = player.income < 0 ? "-" : "+";
		var reputationSign = player.reputation < 0 ? "-" : "+";
		moneyText.text = string.Format(manager.Game.pack.GetMsgLocalization()[0].message + ", "
			+ manager.Game.pack.GetMsgLocalization()[1].message + " ({1}{2})",
			player.money, incomeSign, Mathf.Abs(player.income)
		);
		populationText.text = string.Format(manager.Game.pack.GetMsgLocalization()[2].message + " {0}, "
			+ manager.Game.pack.GetMsgLocalization()[3].message + " ({1}{2})",
			player.population, reputationSign, Mathf.Abs(player.reputation)
		);
	}
}
