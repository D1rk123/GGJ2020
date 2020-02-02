using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
	public GameObject[] breakableWallObjects;
	public GameObject[] playerObjects;

	IBreakable[] _breakableWalls;
	IBreakable[] _playerCharacters;

	private void Awake ()
	{
		_breakableWalls = new IBreakable[breakableWallObjects.Length];
		_playerCharacters = new IBreakable[playerObjects.Length];

		for (int i = 0; i < breakableWallObjects.Length; i++) {
			_breakableWalls[i] = breakableWallObjects[i].GetComponent<IBreakable>();
			_playerCharacters[i] = playerObjects[i].GetComponent<IBreakable>();
		}
	}

	private void Update ()
	{
		bool aPlayerLives = false;
		foreach (IBreakable player in _playerCharacters) {
			if (!player.GetIsBroken()) {
				aPlayerLives = true;
			}
		}
	}

	void RestartGame ()
	{
		SceneManager.LoadScene(0);
	}
}
