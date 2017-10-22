using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
	public GameManager gm;

	private Stack<State> states = new Stack<State>();

	void Awake()
	{
		states.Push (new DefaultState ());
	}

	public void PushState(State state)
	{
		states.Push (state);
	}

	public void PopState()
	{
		if (states.Count > 0)
		{
			states.Pop ();
		}
	}

	void Update()
	{
		if (states.Count > 0)
		{
			states.Peek().Update(this);
		}
	}
}
