using UnityEngine;
using UnityEngine.Events;
public class ManagerActividad : MonoBehaviour
{
    public UnityEvent onCompletarActividad;

    public int cantidadDeRespuestas;
    int respuestasAsignadas = 0;

    public void AgregarRespuestaCorrecta()
    {
        respuestasAsignadas++;

        if (respuestasAsignadas == cantidadDeRespuestas)
        {
            print("Completo Actividad");
            onCompletarActividad.Invoke();
        }

    }

    public void QuitarRespuesta()
    {
        respuestasAsignadas--;
    }




}
