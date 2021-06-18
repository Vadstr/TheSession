using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroController : MonoBehaviour
{
    VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();

        videoPlayer.loopPointReached += videoPlayer_loopPointReached;

        Invoke("Play", 0.5f);
    }

    private void videoPlayer_loopPointReached(VideoPlayer source)
    {
        var sceneManager = new GameObject();
        var manager = sceneManager.AddComponent<MySceneManager>();
        manager.LoadSceneByNumber(1);
    }

    private void Play()
    {
        videoPlayer.Play();
    }
}
