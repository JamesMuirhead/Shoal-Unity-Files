using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackControl : MonoBehaviour
{
    public AudioClip[] tracks;
    public Text trackName;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(shuffleTracks());
    }

    IEnumerator shuffleTracks()
    {
        int nextTrack = 0;
        int currentTrack = 0;

        while (true)
        {
            nextTrack = Random.Range(0, tracks.Length - 1);

            if(nextTrack == currentTrack)
            {
                nextTrack += 1;
            }

            audioSource.clip = tracks[nextTrack];
            audioSource.Play();
            currentTrack = nextTrack;
            trackName.text = tracks[currentTrack].name;

            yield return new WaitWhile(() => audioSource.isPlaying);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
