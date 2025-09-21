using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource src, malluableSrc;
    void Start()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        src.PlayOneShot(clip);
    }

    public void PlaySoundPitchVariance(AudioClip clip, float lowRange, float highRange)
    {
        malluableSrc.pitch = Random.Range(lowRange, highRange);
        malluableSrc.PlayOneShot(clip);
    }
    //this does the startstop thing i mentioned in the #programming channel smile
    public void PlaySoundStartStop(AudioClip clip)
    {
        src.clip = clip;
        src.Play();
    }

}
