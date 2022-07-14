using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventoConTimer : MonoBehaviour
{
    public float waitTime;
    public UnityEvent evento;

    public void EjecutarEvento()
    {
        Invoke("Ejecutar", waitTime);
    }

    void Ejecutar()
    {
        evento.Invoke();
    }
}
