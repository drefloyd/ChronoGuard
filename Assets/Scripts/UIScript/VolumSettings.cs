using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class VolumSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider SFXslider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")||PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicslider.value;
        audioMixer.SetFloat("Music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
       
    }
    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
        private void LoadVolume()
    {
        musicslider.value=PlayerPrefs.GetFloat("musicVolume");
        SFXslider.value=PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
}
