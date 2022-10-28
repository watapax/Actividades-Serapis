using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventosOnEnable : MonoBehaviour
{
    public UnityEvent evento;

    private void OnEnable()
    {
        evento.Invoke();
    }
}
