using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numeros : MonoBehaviour
{
    public SpriteRenderer spr;
    public Sprite[] numeros;
    public AudioSource audioSource;
    public AudioClip[] audioNumeros;
    public int index = 0;


    public void AgregarNumero()
    {
        index++;
        MostrarNumero();
    }
    
    public void QuitarNumero()
    {
        index--;
        MostrarNumero();
    } 

    void MostrarNumero()
    {
        spr.sprite = index ==0? null:  numeros[index];
        audioSource.PlayOneShot(audioNumeros[index]);
    }


}
