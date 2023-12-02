using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source------")]
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip---------")]
    public AudioClip bullet;
    public AudioClip moveSound;
    public AudioClip Teleport;
    public AudioClip explosion;
    public AudioClip GameOver;
    public AudioClip TowertakeDamage;
    public AudioClip DroneDamage;
    public AudioClip Playermove;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip,20);
    }

}
