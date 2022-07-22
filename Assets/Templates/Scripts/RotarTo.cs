using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarTo : MonoBehaviour
{
    Vector3 rotacion;
    float lerpTime = 0.1f;
    bool rotando;
    public void RotarZ(float _angulo)
    {
        if (rotando) return;
        rotacion = transform.localEulerAngles;
        rotacion.z = _angulo;
        StartCoroutine(Rotar());
        rotando = true;
    }

    IEnumerator Rotar()
    {
        float t = 0;
        Vector3 from = transform.localEulerAngles;
        while(t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            transform.localEulerAngles = Vector3.Lerp(from, rotacion, perc);
            yield return null;
        }
    }


    
}
