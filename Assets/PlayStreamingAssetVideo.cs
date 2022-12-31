using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayStreamingAssetVideo : MonoBehaviour
{
    public VideoPlayer SamplePeriodicTableGameplayVideoPlayer;
    //public GameObject InitializeVideoButton;
    public GameObject StartButton;

    // Start is called before the first frame update
    void Start()
    {
        print("loading video now");
        SamplePeriodicTableGameplayVideoPlayer.url = "https://interactivechemistry.org/StreamingVideos/NewPerTableVideo.mp4";
        SamplePeriodicTableGameplayVideoPlayer.Play();
        StartCoroutine(ShowStartButtonAfterDelay());
        //InitializeVideoButton.SetActive(false);

        //string videoURL = "https://interactivechemistry.org/StreamingVideos/PerTableVideo.mp4"; //Application.streamingAssetsPath + "/" + "PerTableVideo" + ".mp4";
        //DELETED DEC 14, 2022
        //SamplePeriodicTableGameplayVideoPlayer.url = "https://interactivechemistry.org/StreamingVideos/PerTableVideo.mp4";
        //SamplePeriodicTableGameplayVideoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playVideo()
    {
        print("loading video now");
        SamplePeriodicTableGameplayVideoPlayer.url = "https://interactivechemistry.org/StreamingVideos/PerTableVideo.mp4";
        SamplePeriodicTableGameplayVideoPlayer.Play();
        //InitializeVideoButton.SetActive(false);
    }

    public IEnumerator ShowStartButtonAfterDelay()
    {
        yield return new WaitForSeconds(2);
        StartButton.SetActive(true);

    }
}
