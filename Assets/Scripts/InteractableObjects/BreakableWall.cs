using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : IInteractable, IBreakable
{
	public GameObject fullWall;
	public GameObject brokenWall;

	bool _isBroken = false;

	public void Interact ()
	{
		if (_isBroken) {

		}
	}

	public void Break ()
	{

	}
}
