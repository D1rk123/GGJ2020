using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
	public GameObject[] breakableWallObjects;
	public GameObject ExplosionParticles;
	public float explodingDuration = 4;
	public float secondsPerExplosion = .2f;

	IBreakable[] _breakableWalls;

	bool _destroyingMountain = false;

	private void Awake ()
	{
		_breakableWalls = new IBreakable[breakableWallObjects.Length];

		for (int i = 0; i < breakableWallObjects.Length; i++) {
			_breakableWalls[i] = breakableWallObjects[i].GetComponent<IBreakable>();
		}
	}

	private void Update ()
	{
		bool anyWallIsFixed = false;
		foreach (IBreakable wall in _breakableWalls) {
			if (!wall.GetIsBroken()) {
				anyWallIsFixed = true;
			}
		}

		if (!anyWallIsFixed && !_destroyingMountain) {
			_destroyingMountain = true;
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
