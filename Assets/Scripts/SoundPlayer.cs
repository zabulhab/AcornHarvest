using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource GameBGM;
    [SerializeField]
    private AudioSource MissSound;
    [SerializeField]
    private AudioSource PowerSound;
    [SerializeField]
    private List<AudioSource> allCollectSFXs;

    //list of sfx
    // random one
    //powerup audio
    // game over audio
    // hurt audio??

    public void PlayRandomCollectSound()
    {
        AudioSource collectSFX = allCollectSFXs[Random.Range(0, allCollectSFXs.Count)];
        collectSFX.Play();
    }

    public void PlayMissSound()
    {
        MissSound.Play();
    }

    public void PlayPowerSound()
    {
        PowerSound.Play();
    }

}
