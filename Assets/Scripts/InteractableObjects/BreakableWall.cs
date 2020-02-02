using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, ISnowDeposit, IBreakable
{
	public GameObject fullWall;
	public GameObject brokenWall;
	public ParticleSystem breakParticles;

	bool _isBroken = false;

	public bool DepositSnow ()
	{
		if (_isBroken) {
			Repair();
			return true;
		}
		return false;
	}

	public void Break ()
	{
		if (!_isBroken) {
			_isBroken = true;
			fullWall.SetActive(false);
			brokenWall.SetActive(true);
			breakParticles.Stop();
			breakParticles.Play();
		}
	}

	public void Repair ()
	{
		if (_isBroken) {
			_isBroken = false;
			fullWall.SetActive(true);
			brokenWall.SetActive(false);
		}
	}

	public bool GetIsBroken ()
	{
		return _isBroken;
	}
}
