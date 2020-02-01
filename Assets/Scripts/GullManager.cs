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

    private bool m_leftGullAlive = false;
    private bool m_rightGullAlive = false;

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
        }
        else
        {
            m_rightGullAlive = true;
        }

        Debug.Log("Spawned gull on the " + GullSideToString(side) + " side");
    }

    public void OnGullRemoved(GullSide side)
    {
        if (side == GullSide.Left)
        {
            m_leftGullAlive = false;
        }
        else
        {
            m_rightGullAlive = false;
        }

        Debug.Log("Gull on the " + GullSideToString(side) + " side was removed");
        StartCoroutine(SpawnGullDelayed(side, getSpawnDelay()));
    }

    void StartGame()
    {
        m_firstGullSide = (Random.Range(0, 1) > 0.5) ? GullSide.Left : GullSide.Right;
        m_secondGullSide = (m_firstGullSide == GullSide.Right) ? GullSide.Left : GullSide.Right;

        StartCoroutine(SpawnGullDelayed(m_firstGullSide, m_firstGullDelay));
        StartCoroutine(SpawnGullDelayed(m_secondGullSide, m_secondGullDelay));
    }


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && m_leftGullAlive)
        {
            OnGullRemoved(GullSide.Left);
        }
        if (Input.GetKeyDown(KeyCode.L) && m_rightGullAlive)
        {
            OnGullRemoved(GullSide.Right);
        }
    }
}
