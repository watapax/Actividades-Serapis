using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSequence : MonoBehaviour
{
    public List<UnityEvent> eventos = new List<UnityEvent>();
    int index;
    public void EjecutarEvento()
    {
        if (index == eventos.Count) return;

        eventos[index].Invoke();
        index++;
    }
}
