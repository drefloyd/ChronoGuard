using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source------")]
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip---------")]
    public AudioClip bullet;
    public AudioClip moveSound;
    public AudioClip gunshotSound;
    public AudioClip explosion;
    public AudioClip powerUpPickup;
    public AudioClip TowertakeDamage;
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip,20);
    }

}
