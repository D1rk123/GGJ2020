using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : InteractableObject
{
	public GameObject fullWall;
	public GameObject brokenWall;

	bool _isBroken = false;

	public override void Interact ()
	{
		if (_isBroken) {

		}
	}

	public void BreakWall ()
	{

	}
}
