using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
	public GameObject[] breakableWallObjects;
	public GameObject[] playerObjects;
	public GameObject ExplosionParticles;
	public float explodingDuration = 4;
	public float secondsPerExplosion = .2f;

	IBreakable[] _breakableWalls;
	IBreakable[] _playerCharacters;

	private void Awake ()
	{
		_breakableWalls = new IBreakable[breakableWallObjects.Length];
		_playerCharacters = new IBreakable[playerObjects.Length];

		for (int i = 0; i < breakableWallObjects.Length; i++) {
			_breakableWalls[i] = breakableWallObjects[i].GetComponent<IBreakable>();
		}
		for (int i = 0; i < playerObjects.Length; i++) {
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
		bool aWallIsFixed = false;
		foreach (IBreakable wall in _breakableWalls) {
			if (!wall.GetIsBroken()) {
				aWallIsFixed = true;
			}
		}

		if (!aPlayerLives || !aWallIsFixed) {
			StartCoroutine(DestroyMountain());
		}
	}

	IEnumerator DestroyMountain ()
	{
		ExplosionParticles.SetActive(true);
		int numberOfExplosions = Mathf.RoundToInt(explodingDuration / secondsPerExplosion);

		for (int i = 0; i < numberOfExplosions; i++) {
			AudioManager.PlayAudioClip(AudioManager.AudioClips.DeathExplosion);
			yield return new WaitForSeconds(secondsPerExplosion);
		}

		RestartGame();
	}

	void RestartGame ()
	{
		SceneManager.LoadScene(0);
	}
}
