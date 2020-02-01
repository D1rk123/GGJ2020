using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    List<Collider> m_pickupObjects = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && m_pickupObjects.Count > 0)
        {
            m_pickupObjects[0].transform.SetParent(gameObject.transform);
            //m_pickupObjects[0].transform.position.y = gameObject.transform.position.y + 0.2;
            Debug.Log("Holding object");
        }

    }
}
