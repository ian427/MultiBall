using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicBar;
    [SerializeField] private Slider sfxBar;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("volumeOfMusic"))
        {
            LoadMusicVolume();
        }

        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float currentVolume = musicBar.value;
        mixer.SetFloat("Music", Mathf.Log(currentVolume) * 20);
        PlayerPrefs.SetFloat("volumeOfMusic", currentVolume);
    }

    public void SetSFXVolume()
    {
        float currentVolume = sfxBar.value;
        mixer.SetFloat("SFX", Mathf.Log(currentVolume) * 20);
        PlayerPrefs.SetFloat("volumeOfSFX", currentVolume);
    }

    private void LoadMusicVolume()
    {
        musicBar.value = PlayerPrefs.GetFloat("volumeOfMusic");
        sfxBar.value = PlayerPrefs.GetFloat("volumeOfSFX");

        SetMusicVolume();
        SetSFXVolume();
    }
}
