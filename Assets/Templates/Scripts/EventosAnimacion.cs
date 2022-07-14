using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventosAnimacion : MonoBehaviour
{
    public UnityEvent evento;

    public void EjecutarEvento()
    {
        evento.Invoke();
    }
}
