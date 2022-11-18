using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolarColor : MonoBehaviour
{
    public Color startColor, endColor;
    public SpriteRenderer sr;
    float lerpTime = 0.3f;
    IEnumerator Start()
    {
        float t = 0;

        while(t<lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            sr.color = Color.Lerp(startColor, endColor, perc);
            yield return null;
        }
    }
}
