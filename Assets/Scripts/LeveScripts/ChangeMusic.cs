using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public AudioClip[] audioClips = new AudioClip[2];
    public EmptyEnemyOnLoc emptyEnemy;

    private void Update()
    {
        if (emptyEnemy.isEmpty == true)
        {
            music.clip = audioClips[0];
            if (music.isPlaying == false)
            {
                music.Play();
            }
        } else
        {
            music.clip = audioClips[1];
            if (music.isPlaying == false)
            {
                music.Play();
            }
        }
    }
}
