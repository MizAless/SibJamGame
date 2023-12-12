using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    public AudioSource[] audioSrc = new AudioSource[1];
    private float musicVolume = 1f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audioSrc.Length; i++)
        {
            audioSrc[i].volume = musicVolume;
        }
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

}
