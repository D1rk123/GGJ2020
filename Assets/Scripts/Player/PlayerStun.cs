using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour, IBreakable
{
	[SerializeField] float stunDuration = 2;

	PlayerMovement _playerMovement;
	bool _isBroken = false;

	void Awake ()
	{
		_playerMovement = GetComponent<PlayerMovement>();
	}

	public void Break ()
	{
		_isBroken = true;
		_playerMovement.enabled = false;
		StartCoroutine(RecoverFromStun());
	}

	public bool GetIsBroken ()
	{
		return _isBroken;
	}

	public void Repair ()
	{
		_isBroken = true;
		_playerMovement.enabled = true;
	}

	IEnumerator RecoverFromStun ()
	{
		yield return new WaitForSeconds(stunDuration);
		Repair();
	}
}