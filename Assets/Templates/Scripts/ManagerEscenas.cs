using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ManagerEscenas : MonoBehaviour
{
    string nombreSiguienteEscena;
    public UnityEvent onLoadScene;
    float waitTime;

    private void Start()
    {
        Cursor.visible = true;
        waitTime = GetComponent<ManagerTransicionCanvas>().duracionFade +1;
    }

    public void CargarEscena(string nombreEscena)
    {
        nombreSiguienteEscena = nombreEscena;
        onLoadScene.Invoke();
        Invoke("Cargar", waitTime);
    }

    void Cargar()
    {   
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}
