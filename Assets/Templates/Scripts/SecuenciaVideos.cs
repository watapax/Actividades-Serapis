using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class SecuenciaVideos : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string[] urlVideos;
    int index = 0;

    private void Start()
    {
        videoPlayer.prepareCompleted += Prepared;
    }

    public void NextVideo()
    {
        if (index == urlVideos.Length) return;

        videoPlayer.url = urlVideos[index];
        videoPlayer.Prepare();

        index++;
    }

    void Prepared(VideoPlayer vPlayer)
    {
        Debug.Log("End reached!");
        vPlayer.Play();
    }


}
