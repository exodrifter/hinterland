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

	public Button foldoutButton;

	private bool hidden = true;

	private Vector3 originalPosition;
	private Vector3 buttonPosition;


	void Awake()
	{
		originalPosition = (transform as RectTransform).anchoredPosition3D;
		buttonPosition = originalPosition;
		buttonPosition.y -= foldoutButton.GetComponent<RectTransform>().anchoredPosition3D.y;
	}

	void Update ()
	{
		var player = manager.Game.players[playerIndex];

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

		if (!hidden)
		{
			(transform as RectTransform).anchoredPosition3D = buttonPosition;
			foldoutButton.GetComponentInChildren<Text>().text = manager.Game.pack.GetMsgLocalization()[7].message;
		}
		else
		{
			(transform as RectTransform).anchoredPosition3D = originalPosition;
			foldoutButton.GetComponentInChildren<Text>().text = manager.Game.pack.GetMsgLocalization()[8].message;
		}

	}

	public void ToggleMarket()
	{
		hidden = !hidden;
	}
}
