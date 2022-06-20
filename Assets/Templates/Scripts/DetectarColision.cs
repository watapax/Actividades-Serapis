using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Evento
{
    public string tag;
    public UnityEvent eventos;

    public void ChequearEvento(string _tag)
    {
        if (_tag == tag)
            eventos.Invoke();
    }

}

public class DetectarColision : MonoBehaviour
{

    public List<Evento> onEnter = new List<Evento>();
    public List<Evento> onStay = new List<Evento>();
    public List<Evento> onExit = new List<Evento>();

    bool cancelarDeteccion;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        RecorrerLista(onEnter, collision.tag);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        RecorrerLista(onStay, collision.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RecorrerLista(onExit, collision.tag);

    }

    void RecorrerLista(List<Evento> _evento, string _tag)
    {
        if (cancelarDeteccion) return;

        for(int i = 0; i < _evento.Count; i++)
        {
            _evento[i].ChequearEvento(_tag);
        }
    }


    public void CancelarDeteccion() => cancelarDeteccion = true;
    

}
