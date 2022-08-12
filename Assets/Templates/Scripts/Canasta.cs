using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Canasta : MonoBehaviour
{
    public UnityEvent onEnterObject, onExitObject, onCountRight, onCountWrong;
    public int cantidadDeObjetosrequeridos;
    int cantidadDeObjetos;

    public void OnEnterObject()
    {
        cantidadDeObjetos++;
        onEnterObject.Invoke();
    }

    public void OnExitObject()
    {
        cantidadDeObjetos--;
        onExitObject.Invoke();
    }

    public void ContarObjetos()
    {
        if (cantidadDeObjetos == cantidadDeObjetosrequeridos)
            onCountRight.Invoke();
        else
            onCountWrong.Invoke();
    }

}
