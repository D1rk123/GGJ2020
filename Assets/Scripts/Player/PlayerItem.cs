using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    List<Collider> m_pickupObjects = new List<Collider>();
    private PlayerInputs m_playerInputs;
    bool m_hasSnow = false;
    Transform m_body;

    private void Start()
    {
        m_playerInputs = GetComponent<PlayerInputs>();
        m_body = transform.GetChild(1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Entered pickup zone");
            m_pickupObjects.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Exited pickup zone");
            m_pickupObjects.Remove(other);
        }
    }

    private void Grow()
    {
        m_body.localScale = new Vector3(1, 1, 1);
    }

    private void Shrink()
    {
        m_body.localScale = new Vector3(0.7f, 0.7f, 1);
    }
	
    void Update()
    {
        if (m_playerInputs.InteractInputDown && m_pickupObjects.Count > 0)
        {
            ISnowResource snowResource = m_pickupObjects[0].gameObject.GetComponent<ISnowResource>();
            if (snowResource != null)
            {
                bool hadSnow = m_hasSnow;
                m_hasSnow = snowResource.GatherSnow() || m_hasSnow;
                if(m_hasSnow && !hadSnow)
                {
                    Grow();
                }
            }

            ISnowDeposit snowDeposit = m_pickupObjects[0].gameObject.GetComponent<ISnowDeposit>();
            if (snowDeposit != null)
            {
                if (m_hasSnow)
                {
                    m_hasSnow = !snowDeposit.DepositSnow();
                    if(!m_hasSnow)
                    {
                        Shrink();
                    }
                }
            }

			AudioManager.PlayAudioClip(AudioManager.AudioClips.InteractSnow);
        }

    }
}
