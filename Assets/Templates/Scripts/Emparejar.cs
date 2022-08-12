using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Emparejar : MonoBehaviour
{
    public Transform pareja;
    public UnityEvent onMatch, onTry, onUnmatch;
    public bool moveToMatchPosition;
   
    Vector3 startPosition;

    bool emparejado;
    bool onRange;



    private void Awake()
    {
        startPosition = transform.position;
    }



    public void BuscarPareja()
    {
        if (emparejado)
        {
            if (onRange) return;
            else
            {
                StartCoroutine(Interpolar(startPosition));
                onUnmatch.Invoke();
                emparejado = false;
            }
        } 
        
        if(onRange)
        {
            if(moveToMatchPosition) StartCoroutine(Interpolar(pareja.position));
            emparejado = true;
            onMatch.Invoke();
        }
        else
        {
            StartCoroutine(Interpolar(startPosition));
           
        }

    }

    IEnumerator Interpolar(Vector3 target)
    {
        Vector3 from = transform.position;
        float t = 0;
        float duracion = 0.3f;
        while(t < duracion)
        {
            t += Time.deltaTime;
            float perc = t / duracion;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(from, target, perc);
            yield return null;
        }

        if (!onRange)
            onTry.Invoke();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == pareja.gameObject)
        {
            onRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onRange = false;
    }

}
