using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullManager : MonoBehaviour
{
    public enum GullSide
    {
        Left,
        Right
    }

    GullSide m_firstGullSide;
    GullSide m_secondGullSide;
    public float m_firstGullDelay = 10;
    public float m_secondGullDelay = 120;
    public float m_respawnAverage = 20;
    public float m_respawnRangeFactor = 5;
    public int m_gullHealth = 3;

    private bool m_leftGullAlive = false;
    private bool m_rightGullAlive = false;
	private int m_numberOfGullsAlive = 0;

    public Seagull m_leftSeagull;
    public Seagull m_rightSeagull;

	public GameObject[] leftBreakableObjects;
    public GameObject[] rightBreakableObjects;
    public GameObject[] playerCharacters;

    public string GullSideToString(GullSide side)
    {
        if (side == GullSide.Right)
            return "right";
        else
            return "left";
    }

    public float getSpawnDelay()
    {
        return Random.Range(m_respawnAverage - m_respawnRangeFactor / 2,
                            m_respawnAverage + m_respawnRangeFactor / 2);
    }

    private IEnumerator SpawnGullDelayed(GullSide side, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(side == GullSide.Left)
        {
            m_leftGullAlive = true;
            m_leftSeagull.Init(new Vector3(-8.25f, -3.64f, -7.42f)+ new Vector3(-15, 0, 0), new Vector3(-8.25f, -3.64f, -7.42f), false, m_gullHealth, leftBreakableObjects, playerCharacters);
			m_numberOfGullsAlive++;
        }
        else
        {
            m_rightGullAlive = true;
            m_rightSeagull.Init(new Vector3(8.14f, -3.64f, -7.42f) + new Vector3(15, 0, 0), new Vector3(8.14f, -3.64f, -7.42f), true, m_gullHealth, rightBreakableObjects, playerCharacters);
			m_numberOfGullsAlive++;
		}

        Debug.Log("Spawned gull on the " + GullSideToString(side) + " side");
		OnGullsUpdate();
	}

    public void OnGullRemoved(bool isLookingLeft)
    {
        GullSide side;
        if (!isLookingLeft)
        {
            m_leftGullAlive = false;
            side = GullSide.Left;
			m_numberOfGullsAlive--;
        }
        else
        {
            m_rightGullAlive = false;
            side = GullSide.Right;
			m_numberOfGullsAlive--;
		}

        Debug.Log("Gull on the " + GullSideToString(side) + " side was removed");
        StartCoroutine(SpawnGullDelayed(side, getSpawnDelay()));
		OnGullsUpdate();
	}

    // Start is called before the first frame update
    void Start()
    {
        m_firstGullSide = (Random.Range(0, 1) > 0.5) ? GullSide.Left : GullSide.Right;
        m_secondGullSide = (m_firstGullSide == GullSide.Right) ? GullSide.Left : GullSide.Right;

        StartCoroutine(SpawnGullDelayed(m_firstGullSide, m_firstGullDelay));
        StartCoroutine(SpawnGullDelayed(m_secondGullSide, m_secondGullDelay));

        m_leftSeagull.gameObject.SetActive(false);
        m_rightSeagull.gameObject.SetActive(false);

        m_leftSeagull.IsRemoved += OnGullRemoved;
        m_rightSeagull.IsRemoved += OnGullRemoved;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.K) && m_leftGullAlive)
        //{
        //    OnGullRemoved(GullSide.Left);
        //}
        //if (Input.GetKeyDown(KeyCode.L) && m_rightGullAlive)
        //{
        //    OnGullRemoved(GullSide.Right);
        //}
    }

	void OnGullsUpdate ()
	{
		AudioManager.SetDanger((AudioManager.MusicDangerLevels) m_numberOfGullsAlive);
	}
}
