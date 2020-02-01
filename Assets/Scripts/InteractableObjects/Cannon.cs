using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, ISnowDeposit
{
    public ParticleSystem m_cameraShotParticles;

    public bool DepositSnow()
    {
        m_cameraShotParticles.Stop();
        m_cameraShotParticles.Play();

        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        CameraShake shaker = mainCamera.GetComponent<CameraShake>();
        StartCoroutine(shaker.Shake(0.2f, 0.05f, true));
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
