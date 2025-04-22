using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISoundController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public TMP_Text _musicPercentText, _sfxPercentText;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void SetMusicVolume()
    {
        AudioManager.Instance.SetMusicVolume(_musicSlider.value);

        _musicPercentText.text = System.Math.Truncate(_musicSlider.value * 100) + "%";
    }

    public void SetSFXVolume()
    {
        AudioManager.Instance.SetSFXVolume(_sfxSlider.value);

        _sfxPercentText.text = System.Math.Truncate(_sfxSlider.value * 100) + "%";
    }
}
