using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoManager : MonoBehaviour
{
    public String SceneName = "WelcomeScene";
    public VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play(); // May avoid buffer pressure
    }

    void OnPrepared(VideoPlayer vp)
    {
        videoPlayer.Play();
    }

    public void nextScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
    public void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneName);
    }
    
}
