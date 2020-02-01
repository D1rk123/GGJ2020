using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    List<Collider> m_pickupObjects = new List<Collider>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Entered pickup zone");
            m_pickupObjects.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Exited pickup zone");
            m_pickupObjects.Remove(other);
        }
    }
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && m_pickupObjects.Count > 0)
        {
            m_pickupObjects[0].transform.SetParent(gameObject.transform);
            Debug.Log("Holding object");
        }

    }
}
