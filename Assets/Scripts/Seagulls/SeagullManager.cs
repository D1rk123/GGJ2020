using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullManager : MonoBehaviour
{
	SeagullSides m_firstGullSide;
	SeagullSides m_secondGullSide;
	public float m_firstGullDelay = 3;
	public float m_secondGullDelay = 10;
	public float m_respawnAverage = 4.5F;
	public float m_respawnRangeFactor = 3;
	public int m_gullHealth = 5;

	private bool m_leftGullAlive = false;
	private bool m_rightGullAlive = false;
	private int m_numberOfGullsAlive = 0;

	public Seagull m_leftSeagull;
	public Seagull m_rightSeagull;

	public GameObject[] leftBreakableObjects;
	public GameObject[] rightBreakableObjects;
	public GameObject[] playerCharacters;


	private IEnumerator SpawnGullDelayed (SeagullSides side, float delay)
	{
		yield return new WaitForSeconds(delay);
		if (side == SeagullSides.Left) {
			m_leftGullAlive = true;
			m_leftSeagull.Init(new Vector3(-8.25f, -3.64f, -0.01000094f) + new Vector3(-10, 0, 0), new Vector3(-8.25f, -3.64f, -0.01000094f), m_gullHealth, leftBreakableObjects, playerCharacters);
		} else {
			m_rightGullAlive = true;
			m_rightSeagull.Init(new Vector3(8.14f, -3.64f, -0.01000094f) + new Vector3(10, 0, 0), new Vector3(8.14f, -3.64f, -0.01000094f), m_gullHealth, rightBreakableObjects, playerCharacters);
		}

		m_numberOfGullsAlive++;

		Debug.Log("Spawned gull on the " + side + " side");
		OnGullsUpdate();
	}

	public void OnGullRemoved (SeagullSides side)
	{
		if (side == SeagullSides.Left) {
			m_leftGullAlive = false;
		} else {
			m_rightGullAlive = false;
		}

		m_numberOfGullsAlive--;
		OnGullsUpdate();

		Debug.Log("Gull on the " + side + " side was removed");
		StartCoroutine(SpawnGullDelayed(side, GetSpawnDelay()));
	}

	void Awake ()
	{
		m_firstGullSide = (Random.Range(0, 2) > 0.5) ? SeagullSides.Left : SeagullSides.Right;
		m_secondGullSide = (m_firstGullSide == SeagullSides.Right) ? SeagullSides.Left : SeagullSides.Right;

		StartCoroutine(SpawnGullDelayed(m_firstGullSide, m_firstGullDelay));
		StartCoroutine(SpawnGullDelayed(m_secondGullSide, m_secondGullDelay));

		m_leftSeagull.gameObject.SetActive(false);
		m_rightSeagull.gameObject.SetActive(false);

		m_leftSeagull.IsRemoved += OnGullRemoved;
		m_rightSeagull.IsRemoved += OnGullRemoved;
	}

	void OnGullsUpdate ()
	{
		AudioManager.SetDanger((AudioManager.MusicDangerLevels) m_numberOfGullsAlive);
	}

	public float GetSpawnDelay ()
	{
		return Random.Range(m_respawnAverage - m_respawnRangeFactor / 2,
							m_respawnAverage + m_respawnRangeFactor / 2);
	}
}
