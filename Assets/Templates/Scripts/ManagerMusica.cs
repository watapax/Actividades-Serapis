using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMusica : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void CambiarVolumen(float _volumen)
    {
        StartCoroutine(SetVolumen(_volumen));
    }

    IEnumerator SetVolumen(float _v)
    {
        float volumen = audioSource.volume;
        float t = 0;

        while(t < 1)
        {
            t += Time.deltaTime;
            float perc = t / 1;
            audioSource.volume = Mathf.Lerp(volumen, _v, perc);
            yield return null;
        }
    }
}
