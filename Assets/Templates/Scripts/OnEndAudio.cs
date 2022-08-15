using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnEndAudio : MonoBehaviour
{
    public UnityEvent onEndAudio;

    public AudioSource audioSource;

    IEnumerator Start()
    {
        audioSource.Play();
        yield return new WaitUntil(() => !audioSource.isPlaying);
        onEndAudio.Invoke();
    }


}
