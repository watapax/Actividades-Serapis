using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[System.Serializable]
public class ObjetoSimple
{
    public string id;
    public AudioClip clip;
}

public class SeleccionAudios : MonoBehaviour
{
    public GameObject[] estrellasIcon;
    public UnityEvent onRespuestaCorrecta, onRespuestaIncorrecta;
    public ObjetoSimple[] objetos;
    List<ObjetoSimple> objetosShuffle = new List<ObjetoSimple>();
    public AudioClip[] estrellas;
    int index = 0;
    public AudioSource audioSource;
    private void Awake()
    {     

        objetosShuffle = objetos.OrderBy(x => Random.value).ToList();
    }

    public void NextAudio()
    {
        if (index == objetosShuffle.Count) return;
        audioSource.PlayOneShot(objetosShuffle[index].clip);

    }

    public void CheckRespuesta(string _respuesta)
    {
        if (objetosShuffle[index].id == _respuesta)
        {
            audioSource.PlayOneShot(estrellas[index]);
            estrellasIcon[index].SetActive(true);
            onRespuestaCorrecta.Invoke();
            index++;
        }
        else
            onRespuestaIncorrecta.Invoke();
    }




}
