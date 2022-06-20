using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolarVolumen : MonoBehaviour
{
    AudioSource audioSource;
    float lerpTime = 1;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CambiarVolumen(float _volumen)
    {
        StartCoroutine(Interpolar(_volumen));
    }

    IEnumerator Interpolar(float _volumen)
    {
        float from = audioSource.volume;

        float t = 0;
        while(t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            audioSource.volume = Mathf.Lerp(from, _volumen, perc);
            yield return null;
        }
    }
}
