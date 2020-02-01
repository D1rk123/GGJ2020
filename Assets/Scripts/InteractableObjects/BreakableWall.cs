using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, ISnowDeposit, IBreakable
{
	public GameObject fullWall;
	public GameObject brokenWall;

	bool _isBroken = false;

	public bool DepositSnow ()
	{
		if (_isBroken) {
			_isBroken = false;
			fullWall.SetActive(true);
			brokenWall.SetActive(false);
			return true;
		}
		return false;
	}

	public void Break ()
	{
		if (!_isBroken) {
			fullWall.SetActive(false);
			brokenWall.SetActive(true);
		}
	}
}
