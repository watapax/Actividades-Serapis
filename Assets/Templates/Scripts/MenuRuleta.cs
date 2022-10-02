using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRuleta : MonoBehaviour
{
    public int opciones;
    public float separacion;
    public Transform menu;
    int index = 0;
    Vector3 nextPos;
    Vector3[] posiciones;
    public AudioClip[] clips;
    public AudioSource audiosource;


    private void Start()
    {
        nextPos = menu.position;
        posiciones = new Vector3[opciones];
        for (int i = 0; i < posiciones.Length; i++)
        {
            posiciones[i] = transform.position;
            posiciones[i].x -= i * separacion;
        }

    }

    public void Next()
    {
        if (index == opciones-1) return;
        index++;
        nextPos = posiciones[index];

        Audio();
        
    }

    public void Prev()
    {
        if (index == 0) return;
        index--;
        nextPos = posiciones[index];
        Audio();
    }


    void Audio()
    {
        audiosource.clip = clips[index];
        audiosource.Play();
    }
    private void Update()
    {
        menu.position = Vector3.Lerp(menu.position, nextPos, Time.deltaTime * 10f);
    }

}
