using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    List<Collider> m_pickupObjects = new List<Collider>();
    private PlayerInputs m_playerInputs;
    bool m_hasSnow = false;

    private void Start()
    {
        m_playerInputs = GetComponent<PlayerInputs>();
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
	
    void Update()
    {
        if (m_playerInputs.InteractInputDown && m_pickupObjects.Count > 0)
        {
            ISnowResource snowResource = m_pickupObjects[0].gameObject.GetComponent<ISnowResource>();
            if (snowResource != null)
            {
                m_hasSnow = snowResource.GatherSnow() || m_hasSnow;
            }

            ISnowDeposit snowDeposit = m_pickupObjects[0].gameObject.GetComponent<ISnowDeposit>();
            if (snowDeposit != null)
            {
                if (m_hasSnow)
                {
                    m_hasSnow = !snowDeposit.DepositSnow();
                }
            }

			AudioManager.PlayAudioClip(AudioManager.AudioClips.InteractSnow);
        }

    }
}
