using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionListener : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public UnityEvent evento;
    Color transparente;
    Color blanco;
    float lerpTime = 2; 

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transparente = new Color(1, 1, 1, 0);
        blanco = Color.white;
    }

    public void CargarEvento(UnityEvent _events)
    {
        evento.RemoveAllListeners();
        evento = _events;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float t = 0;
        while(t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            spriteRenderer.color = Color.Lerp(transparente, blanco, perc);
            yield return null;
        }

        evento.Invoke();
        
        t = 0;
        while (t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            spriteRenderer.color = Color.Lerp(blanco, transparente, perc);
            yield return null;
        }

        evento.RemoveAllListeners();
    }

}
