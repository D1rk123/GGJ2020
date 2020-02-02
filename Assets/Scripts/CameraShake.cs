using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 m_unShakenPos;
    public IEnumerator Shake (float duration, float intensity, bool falloff = false)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float bound = intensity;
            if(falloff)
            {
                bound *= 1 - (elapsed / duration);
            }
            transform.localPosition = new Vector3(
                Random.Range(-bound, bound),
                Random.Range(-bound, bound),
                0
            ) + m_unShakenPos;

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = m_unShakenPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_unShakenPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Shake(3.0f, 1.3f));
        }
    }
}
