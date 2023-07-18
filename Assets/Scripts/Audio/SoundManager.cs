using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public List<AudioSource> AudioClipsList;
    private AudioSource audioSource;
    private bool isMuted;
    public bool IsMuted{
        get{
            return isMuted;
        } 
        set{
            isMuted = value;
            foreach(var audioSource in AudioClipsList){
                audioSource.mute = isMuted;
            }
        }
    }

    public enum AudioClips{
        Click,
        CrystalPickUp,
    }

    public void Start(){
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClips index){
        AudioClipsList[(int)index].Play();
    }
}
