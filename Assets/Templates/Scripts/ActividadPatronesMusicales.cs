using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ActividadPatronesMusicales : MonoBehaviour
{
    public UnityEvent evento;
    public TextMeshPro tmp;
    public AudioSource audioSource;
    bool mostrando;
    public void Activar() => mostrando = false;
    public void SetClip(AudioClip _clip) => clip = _clip; 

    AudioClip clip;


    public void EjecutarEvento(string _txt)
    {
        if(!mostrando)
        {
            audioSource.clip = clip;
            tmp.text = _txt;
            evento.Invoke();
            mostrando = true;
        }
    }


}
