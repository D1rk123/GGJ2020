using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XInputDotNetExtended;

public class PlayerMovement : MonoBehaviour
{
    public PlayerIndex m_playerIndex;
    public float m_movementSpeed = 5;
    public float m_acceleration = 20;
    public float m_deceleration = 40;
    public float m_stopSpeed = 0.5f;
    public float m_jumpSpeed = 10.0f;
    public float m_geyserAcceleration = 20.0f;
    public float m_geyserMaxSpeed = 10;
    public LayerMask m_collisionMask;

    private Rigidbody m_rigidbody;
    private Collider m_collider;
    private PlayerInputs m_playerInputs;
    private List<Collider> m_geysers = new List<Collider>();
    private float m_desiredVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = transform.GetComponentInChildren<Collider>();
        m_playerInputs = GetComponent<PlayerInputs>();
    }

    private void FixedUpdate()
    {
        Vector3 v = m_rigidbody.velocity;

        if (m_desiredVelocity < 0)
        {
            if (v.x < m_desiredVelocity)
            {
                v.x += m_deceleration * Time.fixedDeltaTime;
                v.x = Mathf.Min(v.x, m_desiredVelocity);
            }
            if (v.x > m_desiredVelocity)
            {
                v.x -= m_acceleration * Time.fixedDeltaTime;
                v.x = Mathf.Max(v.x, m_desiredVelocity);
            }
        }
        if (m_desiredVelocity > 0)
        {
            if (v.x < m_desiredVelocity)
            {
                v.x += m_acceleration * Time.fixedDeltaTime;
                v.x = Mathf.Min(v.x, m_desiredVelocity);
            }
            if (v.x > m_desiredVelocity)
            {
                v.x -= m_deceleration * Time.fixedDeltaTime;
                v.x = Mathf.Max(v.x, m_desiredVelocity);
            }
        }
        if (m_desiredVelocity == 0)
        {
            if (v.x < 0)
            {
                v.x += m_deceleration * Time.fixedDeltaTime;
                v.x = Mathf.Min(0, v.x);
            }
            if (v.x > 0)
            {
                v.x -= m_deceleration * Time.fixedDeltaTime;
                v.x = Mathf.Max(0, v.x);
            }
            if (Mathf.Abs(v.x) < m_stopSpeed)
            {
                v.x = 0;
            }
        }

        m_rigidbody.velocity = v;

        if(m_geysers.Count > 0)
        {
            m_rigidbody.AddForce(new Vector3(0, m_geyserAcceleration, 0), ForceMode.Acceleration);
            v = m_rigidbody.velocity;
            v.y = Mathf.Min(m_geyserMaxSpeed, v.y);
            m_rigidbody.velocity = v;
        }
    }

    private void Update()
    {
        m_desiredVelocity = m_playerInputs.MovementInput * m_movementSpeed;

        Vector3 extents = m_collider.bounds.extents;

        Collider[] collisions = Physics.OverlapBox(
            m_collider.bounds.center + Vector3.down * 0.02f, m_collider.bounds.extents - new Vector3(0.01f, 0.01f, 0.01f), m_collider.transform.rotation, m_collisionMask.value
            );

        if (m_playerInputs.JumpInputDown &&
            collisions.Any(c => !c.isTrigger))
        {
            Debug.Log("Number of collision: " + collisions.Length);
            Vector3 v = m_rigidbody.velocity;
            v.y = m_jumpSpeed;
            m_rigidbody.velocity = v;
        }
    }

    private void OnTriggerEnter(Collider geyser)
    {
        if(geyser.CompareTag("Geyser"))
        {
            m_geysers.Add(geyser);
			AudioManager.PlayAudioClip(AudioManager.AudioClips.Geyser);
        }
    }

    private void OnTriggerExit(Collider geyser)
    {
        if (geyser.CompareTag("Geyser"))
        {
            m_geysers.Remove(geyser);
        }
    }
}
