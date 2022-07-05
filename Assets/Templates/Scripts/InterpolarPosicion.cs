using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InterpolarPosicion : MonoBehaviour
{
    public Transform objetoTransform;
    public UnityEvent onComplete;
    public bool useLocalTransform = false;
    bool isActive;

    public void MoverA(Transform _target)
    {
        if (isActive) return;
        StartCoroutine(Interpolar(_target.position));
        isActive = true;
    }

    IEnumerator Interpolar(Vector3 target)
    {
        Vector3 from = useLocalTransform? transform.position: objetoTransform.position;
        float t = 0;
        float duracion = 0.3f;

        while (t < duracion)
        {
            t += Time.deltaTime;
            float perc = t / duracion;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            if(useLocalTransform)
            {
                transform.position = Vector3.Lerp(from, target, perc);
            }
            else
            {
               objetoTransform.position = Vector3.Lerp(from, target, perc);
            }
            yield return null;
        }

        onComplete.Invoke();
        isActive = false;


    }
}
