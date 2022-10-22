using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Linq;

public class CalcularRespuesta : MonoBehaviour
{
    public string[] url;
    public VideoPlayer videoPlayer;
    int[] respuestas = new int[3];
    //0 = auditivo  , 1 = visual , 2 = kinestesico;

    
    public void AgregarRespuesta(int index)
    {
        respuestas[index]++;
    }

    public void Calcular()
    {
        int maxValue = respuestas.Max();
        int index = respuestas.ToList().IndexOf(maxValue);

        videoPlayer.url = url[index];
        videoPlayer.gameObject.SetActive(true);
    }
}
