using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SlotMusicales : MonoBehaviour
{
    public UnityEvent onEndPatron;
    public AudioSource audioSource;
    public AudioClip[] clips;
    int index;
    public void PlaySlot()
    {
        if(index == clips.Length)
        {
            index = 0;
        }

        audioSource.PlayOneShot(clips[index]);
        index++;
    }

    public void Fin()
    {
        onEndPatron.Invoke();
    }

    
}
