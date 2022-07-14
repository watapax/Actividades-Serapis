using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CheckSeleccionCorrecta : MonoBehaviour
{
    public UnityEvent onRespuestaCorrecta, onRespuestaIncorrecta;
    string respuestaCorrecta;
    public string[] respuestas;

    public void DefinirRespuesta(int _index)
    {
        respuestaCorrecta = respuestas[_index];
    }

    public void CheckRespuesta(int _index)
    {
        if (respuestas[_index] == respuestaCorrecta)
            onRespuestaCorrecta.Invoke();
        else
            onRespuestaIncorrecta.Invoke();
    }
}
