using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerTransicionCanvas : MonoBehaviour
{
    public Image cuadroBlanco;
    public float duracionFade = 1.5f;
    Color blanco = Color.white;
    Color transparente =  new Color(1, 1, 1, 0);
    bool lerping;
    public bool fadeoutOnAwake;

    private void Awake()
    {
        if (fadeoutOnAwake)
        {
            cuadroBlanco.color = blanco;
            FadeOutBlanco();
        }
    }


    public void FadeInBlanco()
    {
        if(!lerping)
            StartCoroutine(Fade( blanco));
    }   
    
    public void FadeOutBlanco()
    {
        if(!lerping)
            StartCoroutine(Fade(transparente));
    }

    IEnumerator Fade( Color _toColor)
    {
        Color _fromColor = cuadroBlanco.color;
        lerping = true;
        float t = 0;
        while(t < duracionFade)
        {
            t += Time.deltaTime;
            float perc = t / duracionFade;
            cuadroBlanco.color = Color.Lerp(_fromColor, _toColor, perc);
            yield return null;
        }
        lerping = false;
        
    }

}
