using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public Vector3 m_shotStartPos = new Vector3(0, 0, 0);
    public Vector3 m_shotDirection = new Vector3(-1, 0.3f, 0);
    public float m_shotSpeed = 40;
    public float m_disableTime = 2;
    public ParticleSystem m_onImpactParticles;

    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] collisions = Physics.OverlapSphere(
            transform.position, transform.localScale.y/2, (1 << 9)
            );
        if (collisions.Length > 0)
        {
            m_onImpactParticles.transform.position = transform.position;
            m_onImpactParticles.Stop();
            m_onImpactParticles.Play();

            Seagull gull = collisions[0].transform.parent.gameObject.GetComponent<Seagull>();
            gull.ReceiveDamage(1);

            gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        transform.localPosition = m_shotStartPos;
        //m_rigidbody.AddRelativeForce(m_shotDirection.normalized * m_shotSpeed, ForceMode.VelocityChange);
        
        m_rigidbody.velocity = transform.localToWorldMatrix * m_shotDirection.normalized * m_shotSpeed;
        m_rigidbody.useGravity = true;
    }
}
