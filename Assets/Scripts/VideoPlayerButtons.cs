using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerButtons : MonoBehaviour
{
    public VideoPlayer[] videoPlayers;
    private int currentVideoIndex = -1;
    
    void Start()
    {
        DisableAllVideos();
    }
    public void VideoDisable()
    {
        DisableAllVideos();
    }
   
    public void CallVideoByIndex(int index)
    {
        if (index < 0 || index >= videoPlayers.Length) return;       
        if (currentVideoIndex != -1)
        {
            videoPlayers[currentVideoIndex].Stop();
            videoPlayers[currentVideoIndex].gameObject.SetActive(false);
        }
        videoPlayers[index].gameObject.SetActive(true);
        videoPlayers[index].Play();
        currentVideoIndex = index;        
        //BaseMapChanger.Instance.AudioStop();
    }
    public void PauseAllVideos()
    {
        foreach (var vp in videoPlayers)
        {
            vp.Pause();
        }
    }
    public void StopAllVideos()
    {
        foreach (var vp in videoPlayers)
        {
            vp.Stop();
            vp.gameObject.SetActive(false);
        }
        currentVideoIndex = -1;
    }
    private void DisableAllVideos()
    {
        foreach (var vp in videoPlayers)
        {
            vp.gameObject.SetActive(false);
        }
    }
   
}
