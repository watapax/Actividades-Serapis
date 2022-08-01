using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class SecuenciaVideos : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public UnityEvent onEndSequence;
    public float delayTime;
    public string[] urlVideos;
    int index = 0;

    private void Start()
    {
        videoPlayer.prepareCompleted += Prepared;
    }

    public void NextVideo()
    {
        if (index == urlVideos.Length)
        {
            onEndSequence.Invoke();
            return;
        }

        videoPlayer.url = urlVideos[index];
        videoPlayer.Prepare();

        index++;
    }

    void Prepared(VideoPlayer vPlayer)
    {
        Debug.Log("End reached!");
        vPlayer.Play();
        if(delayTime > 0)
        {
            StartCoroutine(DelayVideo());
        }
    }

    IEnumerator DelayVideo()
    {
        yield return new WaitForEndOfFrame();
        videoPlayer.Pause();
        yield return new WaitForSeconds(delayTime);
        videoPlayer.Play();
    }

}
