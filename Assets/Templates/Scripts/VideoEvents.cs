using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class VideoEvents : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public UnityEvent onVideoEnd;

    //bool videoEnd;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();  
        videoPlayer.loopPointReached += EndVideo;
    }

    void EndVideo(VideoPlayer vp)
    {
        onVideoEnd.Invoke();
    }





}
