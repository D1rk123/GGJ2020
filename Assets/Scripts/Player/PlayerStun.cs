using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour, IBreakable
{
	public GameObject stunSprite;
	[SerializeField] float stunDuration = 2;
	[SerializeField] PlayerMovement _playerMovement;

	bool _isBroken = false;

	void Awake ()
	{
		if (_isBroken) {
			_playerMovement.enabled = false;
			stunSprite.SetActive(true);
		} else {
			_playerMovement.enabled = true;
			stunSprite.SetActive(false);
		}
	}

	public void Break ()
	{
		stunSprite.SetActive(true);
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
		stunSprite.SetActive(false);
		_isBroken = false;
		_playerMovement.enabled = true;
	}

	IEnumerator RecoverFromStun ()
	{
		yield return new WaitForSeconds(stunDuration);
		Repair();
	}
}
