using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
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
            );

            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
