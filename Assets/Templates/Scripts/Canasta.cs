using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Canasta : MonoBehaviour
{
    public UnityEvent onEnterObject;
    public int cantidadDeObjetos;

    public void OnEnterObject()
    {
        cantidadDeObjetos++;
        onEnterObject.Invoke();
    }

}
