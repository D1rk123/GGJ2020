using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    //private float fallingVelocity;
    private Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        //fallingVelocity = 0;
        //m_Collider = GetComponent<Collider>();
    }

    private void Update()
    {
        const int playerMask = 1 << 7;
        const int collisionMask = Physics.DefaultRaycastLayers & ~playerMask;

        Vector3 v = m_rb.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            v.x = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            v.x = -3;
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            v.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.W) &&
            Physics.Raycast(transform.position, Vector3.down, 0.501f, collisionMask))
        {
            v.y += 10;
        }
        m_rb.velocity = v;
    }

    /*
    // Update is called once per frame
    void FixedUpdate()
    {
        //const int playerMask = 1 << 8;
        const int collisionMask = Physics.DefaultRaycastLayers;// & ~playerMask;
        const float movementSpeed = 3;
        const float jumpSpeed = 15f;
        const float gravitationalAcceleration = 20f;
        const float terminalVelocity = 30f;

        Vector3 posDelta = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            posDelta += Vector3.right * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            posDelta += Vector3.left * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            posDelta += Vector3.up * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            posDelta += Vector3.down * movementSpeed * Time.fixedDeltaTime;
        }
        if (onSurface && Input.GetKey(KeyCode.W))
        {
            fallingVelocity = jumpSpeed;
        }

        fallingVelocity -= gravitationalAcceleration * Time.fixedDeltaTime;
        fallingVelocity = Mathf.Clamp(fallingVelocity, -terminalVelocity, terminalVelocity);
        posDelta.y += fallingVelocity * Time.fixedDeltaTime;

        RaycastHit hitInfo;
        if (posDelta.magnitude > 0.01 &&
            Physics.BoxCast(
                m_Collider.bounds.center,
                m_Collider.bounds.extents,
                posDelta.normalized,
                out hitInfo,
                transform.rotation,
                posDelta.magnitude,
                collisionMask
            )
        )
        {
            //Vector3 partialPosDelta = posDelta.normalized * hitInfo.distance;
            //posDelta -= partialPosDelta;
            fallingVelocity -= fallingVelocity * Vector3.Dot(hitInfo.normal, posDelta); ;
            posDelta -= hitInfo.normal * Vector3.Dot(hitInfo.normal, posDelta);
            transform.position += posDelta;
        }
        else
        {
            transform.position += posDelta;
        }

        if (Physics.Raycast(transform.position, Vector3.down, 0.7f, collisionMask))
        {
            fallingVelocity = 0;
            onSurface = true;
        }
        else
        {
            onSurface = false;
        }
    }//*/
}
