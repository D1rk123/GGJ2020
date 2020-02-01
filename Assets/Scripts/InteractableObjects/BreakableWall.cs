using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, IInteractable, IBreakable
{
	public GameObject fullWall;
	public GameObject brokenWall;

	bool _isBroken = false;

	public void Interact ()
	{
		if (_isBroken) {
			_isBroken = false;
			fullWall.SetActive(true);
			brokenWall.SetActive(false);
		}
	}

	public void Break ()
	{
		if (!_isBroken) {
			fullWall.SetActive(false);
			brokenWall.SetActive(true);
		}
	}
}
