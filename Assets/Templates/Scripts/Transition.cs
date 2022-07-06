using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Transition : MonoBehaviour
{
    TransitionListener transitionListener;
    public UnityEvent evento;

    private void Awake()
    {
        transitionListener = (TransitionListener) FindObjectOfType(typeof(TransitionListener));
    }

    public void CargarTransicion()
    {
        transitionListener.CargarEvento(evento);
    }
}
