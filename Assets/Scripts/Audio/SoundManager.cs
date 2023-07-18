using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public List<AudioClip> AudioClipsList;
    private AudioSource audioSource;

    public enum AudioClips{
        Click
    }

    public void Start(){
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClips index){
        if(audioSource.isPlaying){
            audioSource.Stop();
        }
        audioSource.clip = AudioClipsList[(int)index];
        audioSource.Play();
    }
}
