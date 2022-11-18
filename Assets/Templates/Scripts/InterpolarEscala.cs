using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolarEscala : MonoBehaviour
{
    public bool startOnAwake;
    public float endScale;
    Vector3 startScale;
    Vector3 newScale;
    float lerpTime = 0.3f;
    private void Start()
    {
        startScale = transform.localScale;
        newScale = startScale * endScale;

        if (startOnAwake)
            Interpolar();
    }

    public void Interpolar()
    {
        StartCoroutine(InterpolarScale());
    }

    IEnumerator InterpolarScale()
    {
        float t = 0;
        while(t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            transform.localScale = Vector3.Lerp(startScale, newScale, perc);
            yield return null;
        }

    }
}
