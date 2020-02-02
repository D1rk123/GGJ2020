using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
	public GameObject[] breakableWalls;
	public GameObject[] playerCharacters;

	IBreakable[] _breakableWalls;
	IBreakable[] _playerCharacters;

	private void Awake ()
	{
		_breakableWalls = new IBreakable[breakableWalls.Length];
		_playerCharacters = new IBreakable[playerCharacters.Length];

		for (int i = 0; i < breakableWalls.Length; i++) {
			_breakableWalls[i] = breakableWalls[i].GetComponent<IBreakable>();
			_playerCharacters[i] = playerCharacters[i].GetComponent<IBreakable>();
		}
	}

	private void Update ()
	{
		
	}

	void RestartGame ()
	{
		SceneManager.LoadScene(0);
	}
}
