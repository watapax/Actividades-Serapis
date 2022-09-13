using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public void SetClip(AudioClip _clip)
    {
        audioSource.clip = _clip;
    }

    public void PlayAudio(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }
}
