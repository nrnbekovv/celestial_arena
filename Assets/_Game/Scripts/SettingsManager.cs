using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle shadowsToggle;

    void Start()
    {
        volumeSlider.value = AudioListener.volume;

        shadowsToggle.isOn =
            QualitySettings.shadows != ShadowQuality.Disable;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ToggleShadows(bool enabled)
    {
        if (enabled)
        {
            QualitySettings.shadows = ShadowQuality.All;
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
    }
}