using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{
    private VideoPlayer  videoPlayer;

    [SerializeField] private GameObject _loadingText;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        string videoPath = Path.Combine(Application.streamingAssetsPath, "Post_Inreo1.mp4");
        videoPlayer.url = videoPath;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;
        UnityEngine.Debug.Log("Preparing video from path: " + videoPath);
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video prepared, starting playback.");
        _loadingText.SetActive(false);
        vp.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.prepareCompleted -= OnVideoPrepared;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video Ended, loading scene.");
        videoPlayer.loopPointReached -= OnVideoEnd;
        SceneManager.LoadScene("Sceneworld");
    }
}
